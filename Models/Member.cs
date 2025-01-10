using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Member
    {
        public int ID { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Full Name")]
        public string Name { get; set; } // Numele complet

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Membership { get; set; } // Basic, Premium

        [Required]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
    }
}
