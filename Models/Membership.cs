using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Membership
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Membership Type")]
        public string Type { get; set; } // ex: Basic, Premium

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [StringLength(200)]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
