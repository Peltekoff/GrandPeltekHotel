using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrandPeltekHotel.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User ReservationUser { get; set; }
        public int CategoryId { get; set; }
        //public int NumberOfBookedRooms { get; set; }
    }
}
