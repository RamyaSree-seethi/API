using System.ComponentModel.DataAnnotations;

namespace StayHappy.Models
{
    public class RoomDetails
    {
        [Key]
        public int RoomId { get; set; }
        [Required] 
        public string RoomType{ get; set; }
        [Required]
        public string Facilities { get; set;}
        [Required]
        public string PhotoUrl { get; set; }
        [Required]
        public int AdultsCount { get; set;}
        [Required]
        public int ChildCount { get;set;}
        [Required]
        public decimal Price{ get; set; }

        [Required]
        public int Rating { get; set; }
        //[Required]
        //public bool IsBooked { get; set; }

    }
}
