using System.ComponentModel.DataAnnotations;

namespace StayHappy.Models
{
    public class RegisterUsers
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]

        [StringLength(50)]
        public string Email { get; set; }
        [Required]

        [StringLength(50)]
        public string Password { get; set; }
       
        [Required]
        [StringLength(50)]
        public string ConfirmPassword { get; set; }
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
    }
}
