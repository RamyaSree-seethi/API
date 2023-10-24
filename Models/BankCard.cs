using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using StayHappy.Models;
using System.Threading.Tasks;

namespace StayHappy.Models
{
    public class BankCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "ID will be automatically generated")]
        public int BankCredId { get; set; }

      

        [MinLength(16, ErrorMessage = "Atleast 16 digits")]
        [MaxLength(16, ErrorMessage = "Maximum 16 digits")]
        [Required(ErrorMessage = "Enter the last four digits of you card number.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "The expirydate name cannot be empty.")]

        public string ExpiryDate { get; set; }

        public int CVV { get; set; }

        [Required(ErrorMessage = "The upi name cannot be empty.")]
        public string ybl { get; set; }
    }
}