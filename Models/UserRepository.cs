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
        

        

        

        public void UpdateUserInfo(User user, out User updatedUser)
        {
            User userToBeUpdated = _appDbContext.Users.First(u => u.Id == user.Id);

            userToBeUpdated.Email = user.Email;
            userToBeUpdated.FirstName = user.FirstName;
            userToBeUpdated.LastName = user.LastName;

            _appDbContext.SaveChanges();

            updatedUser = userToBeUpdated;
        }
    }
}
