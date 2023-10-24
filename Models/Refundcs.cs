using System;
using System.ComponentModel.DataAnnotations;

namespace StayHappy.Models
{
    public class Refund
    {
        [Key]
        public int RefundId { get; set; }
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime? ProcessedDate { get; set; }

    }
}