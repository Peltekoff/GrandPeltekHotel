using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GrandPeltekHotel.Models;
using GrandPeltekHotel.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrandPeltekHotel.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly AppDbContext _appDbContext;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserController(UserRepository userRepository, AppDbContext appDbContext, 
            SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _appDbContext = appDbContext;
            _signInManager = signInManager;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password,
                    model.RememberMe, false);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model); 
        }

        
        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult UserProfile()
        {
            User loggedInUser = _appDbContext.Users.FirstOrDefault(u => u.UserName == HttpContext.User.Identity.Name);

            UserProfileViewModel userProfileViewModel = new UserProfileViewModel
            {
                Email = loggedInUser.Email,
                FirstName = loggedInUser.FirstName,
                LastName = loggedInUser.LastName,
                PhoneNumber = loggedInUser.PhoneNumber,
                NumberOfReservations = _appDbContext.Reservations.Where(r => r.ReservationUser == loggedInUser).Count()
            };

            if (loggedInUser == null)
            {
                return Login();
            }
            else
            {
                return View(userProfileViewModel);
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            User regAttemptUser = new User();
            if(ModelState.IsValid)
            {
                var newUser = new User { UserName = model.Email, Email = model.Email, FirstName = model.FirstName,
                LastName = model.LastName, PhoneNumber = model.PhoneNumber};
                var result = await _userManager.CreateAsync(newUser, model.Password);

                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, isPersistent: false);
                    regAttemptUser = newUser;
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return RedirectToAction("UserProfile");
        }
        [HttpGet]
        public IActionResult EditUserInfo(User user)
        {
            User loggedInUser = _appDbContext.Users.FirstOrDefault(u => u.UserName == HttpContext.User.Identity.Name);

            if (loggedInUser == null)
            {
                return Login();
            }
            else
            {
                return View(loggedInUser);
            }
        }

        public IActionResult UpdateUserInfo(User user)
        {
            User checkForSameEmail = _appDbContext.Users.First(u => u.Email == user.Email);
            User loggedInUser = _appDbContext.Users.FirstOrDefault(u => u.UserName == HttpContext.User.Identity.Name);

            if (_appDbContext.Users != null && checkForSameEmail != null && checkForSameEmail != loggedInUser)
            {
                ModelState.AddModelError("", "User with the same email already exists");
            }
            User updatedUser;
            if (ModelState.IsValid)
            {
                
                _userRepository.UpdateUserInfo(user, loggedInUser, out updatedUser);
            }
            else
            {
                updatedUser = user;
            }

            return RedirectToAction("UserProfile");
        }
    }
}
