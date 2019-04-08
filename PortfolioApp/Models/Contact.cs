using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApp.Models
{
    public class Contact
    {
        [Key]
        public int FeedbackId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Field has to contain between 3 and 20 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Field has to contain between 3 and 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 20, ErrorMessage = "Field has to contain between 20 and 2000 characters.")]
        public string Message { get; set; }
    }
}
