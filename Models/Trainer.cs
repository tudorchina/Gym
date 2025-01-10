using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Trainer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Specialization { get; set; } // Ex: Fitness, Yoga

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }
    }
}
