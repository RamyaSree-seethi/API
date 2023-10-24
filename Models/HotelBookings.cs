using System;
using System.ComponentModel.DataAnnotations;

namespace StayHappy.Models
{
    public class HotelBookings
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        
        public int UserId { get; set; }
        public int RoomId { get; set; }
       
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public decimal price { get; set; }

        public RegisterUsers User { get; set; }
        public RoomDetails RoomDetail { get; set; }

    }

}
