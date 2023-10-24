using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StayHappy.Models
{
    public class feedback
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Rating { get; set; }
        
        public string Comment { get; set; }
        [Required]
        [ForeignKey("Room")]
        public int RoomId { get; set; } // This will be the foreign key property

        public RoomDetails Room { get; set; } // Navigation property to the related Room entity

        [Required]
        public string UserName{ get; set; }

    }
}
