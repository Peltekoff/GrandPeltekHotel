using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrandPeltekHotel.ViewModels
{
    public class UserProfileViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfReservations { get; set; }
    }
}
