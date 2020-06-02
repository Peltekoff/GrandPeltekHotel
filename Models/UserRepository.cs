using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrandPeltekHotel.Models
{
    public class UserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<User> AllUsers => _appDbContext.Users;






        public void UpdateUserInfo(User user, User loggedInUser, out User updatedUser)
        {

            User userToBeUpdated = loggedInUser;

            userToBeUpdated.Email = user.Email;
            userToBeUpdated.FirstName = user.FirstName;
            userToBeUpdated.LastName = user.LastName;

            _appDbContext.SaveChanges();

            updatedUser = userToBeUpdated;
        }
    }
}
