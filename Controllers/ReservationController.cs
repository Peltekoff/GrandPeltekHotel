using GrandPeltekHotel.Models;
using GrandPeltekHotel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrandPeltekHotel.Controllers
{
    public class ReservationController: Controller
    {
        private readonly UserRepository _userRepository;
        private readonly AppDbContext _appDbContext;

        public ReservationController(UserRepository userRepository, AppDbContext appDbContext)
        {
            _userRepository = userRepository;
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult Reservation()
        {
            User loggedInUser = _appDbContext.Users.FirstOrDefault(u => u.UserName == HttpContext.User.Identity.Name);

            if(loggedInUser == null)
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }
        [HttpPost]
        public IActionResult Reservation(ReservationViewModel reservation)
        {

            User loggedInUser = _appDbContext.Users.FirstOrDefault(u => u.UserName == HttpContext.User.Identity.Name);

            int numberOfRoomsForChosenCategory = _appDbContext.Rooms.Where(r => r.CategoryId == reservation.CategoryId).Count();

            List<Reservation> reservationsForChosenPeriod = new List<Reservation>();

            foreach (Reservation r in _appDbContext.Reservations.Where(r => r.CategoryId == reservation.CategoryId 
                                                 && ((r.FromDate >= reservation.FromDate && r.FromDate > reservation.ToDate) ||
                                                 (r.ToDate >= reservation.FromDate && r.ToDate < reservation.ToDate)) ||
                                                 (r.FromDate < reservation.FromDate && r.ToDate > reservation.ToDate)))
            {
                reservationsForChosenPeriod.Add(r);
            }

            if((numberOfRoomsForChosenCategory - reservationsForChosenPeriod.Count) >= reservation.NumberOfBookedRooms)
            {
                for (int i = 1; i <= reservation.NumberOfBookedRooms; i++)
                {
                    Reservation successfulReservation = new Reservation
                    {
                        CategoryId = reservation.CategoryId,
                        FromDate = reservation.FromDate,
                        ToDate = reservation.ToDate,
                        ReservationUser = loggedInUser
                    };

                    _appDbContext.Reservations.Add(successfulReservation);
                    _appDbContext.SaveChanges();
                }

                return RedirectToAction("BookingSuccessful", reservation);
            }
            else
            {
                reservation.NumberOfBookedRooms = (numberOfRoomsForChosenCategory - reservationsForChosenPeriod.Count);
                return RedirectToAction("BookingFailed", reservation);
            }
        }

        [HttpGet]
        public IActionResult CheckAvailability()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckAvailability(ReservationViewModel model)
        {
            int availableRoomsForChosenPeriodForTheCategory;

            int numberOfRoomsInChosenCategory = _appDbContext.Rooms.Where(r => r.CategoryId == model.CategoryId).Count();

            int reservationsForChosenPeriodForTheCategory = _appDbContext.Reservations
                                                            .Where(r => (r.FromDate > model.FromDate && r.FromDate < model.ToDate)
                                                            || (r.FromDate < model.FromDate && r.ToDate > model.FromDate)
                                                            || (r.ToDate > model.FromDate && r.ToDate < model.ToDate)).Count();

            if(numberOfRoomsInChosenCategory > reservationsForChosenPeriodForTheCategory)
            {
                availableRoomsForChosenPeriodForTheCategory = numberOfRoomsInChosenCategory - reservationsForChosenPeriodForTheCategory;
            }
            else
            {
                availableRoomsForChosenPeriodForTheCategory = 0;
            }

            model.NumberOfBookedRooms = availableRoomsForChosenPeriodForTheCategory;

            return RedirectToAction("ShowAvailability", model);
        }

        public ViewResult ShowAvailability(ReservationViewModel model)
        {
            return View(model);
        }

        public ViewResult BookingSuccessful(ReservationViewModel reservation)
        {
            
            return View(reservation);
        }

        public ViewResult BookingFailed(ReservationViewModel reservation)
        {
            
            return View(reservation);
        }
    }
}
