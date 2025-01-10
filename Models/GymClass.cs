using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class GymClass
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } // Ex.: Yoga, Cardio

        [Required]
        public string Description { get; set; } // Detalii despre clasă

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Class Date and Time")]
        public DateTime DateTime { get; set; } // Data și ora clasei

        [Required]
        public int Capacity { get; set; } // Număr maxim de participanți
        public bool IsPremium { get; set; }


        public int? TrainerID { get; set; } // FK către Trainers
        public Trainer? Trainer { get; set; } // Relația cu Trainer
    }
}
