using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Member
    {
        public int ID { get; set; }


        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Full Name")]
        public string? Name { get; set; } // Numele complet

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau'0722.123.123' sau '0722 123 123'")]

        public string? Phone { get; set; }

        
        public string? Membership { get; set; } // Basic, Premium

        
        [DataType(DataType.Date)]
        public DateTime? RegistrationDate { get; set; }
    }
}
