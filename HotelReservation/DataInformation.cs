using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation
{
    public class customerReservation
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long MobileNo { get; set; }
        public string  Nationality { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ID_No { get; set; }
        public string Address { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public string RoomNo { get; set; }
        public string RoomType { get; set; }
        public long Price { get; set; }
        public string ac { get; set; }
    }

    public class Rooms 
    {
        public long ID { get; set; }
        public string  RoomNo { get; set; }
        public string RoomType { get; set; }
        public string AC_NonAC { get; set; }
        public string checkOut { get; set; }
        public long Price { get; set; }
    }
}
