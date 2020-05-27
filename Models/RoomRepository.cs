using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrandPeltekHotel.Models
{
    public class RoomRepository
    {
        private readonly AppDbContext _appDbContext;

        public RoomRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Room> AllRooms => _appDbContext.Rooms;
    }
}
