namespace Gym.Models
{
    public class Participation
    {
        public int ID { get; set; }

        // FK către Member
        public int? MemberID { get; set; }
        public Member? Member { get; set; }

        // FK către GymClass
        public int? GymClassID { get; set; }
        public GymClass? GymClass { get; set; }
    }
}
