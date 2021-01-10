namespace MindYourMoodWeb.Entities
{
    public class SafetyPlanCard : Entity
    {
        //public int Id { get; set; }
        public string CalmMyself { get; set; }
        public string TellMyself { get; set; }
        public string WillCall { get; set; }
        public string WillGoTo { get; set; }
        public AppUser User { get; set; }
    }
}
