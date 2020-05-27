using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrandPeltekHotel.ViewModels
{
    public class ReservationViewModel
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int CategoryId { get; set; }
        public int NumberOfBookedRooms { get; set; }
    }
}
