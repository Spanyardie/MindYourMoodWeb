namespace MindYourMoodWeb.Entities
{
    public class TellMyself : Entity
    {
        public string TellText { get; set; }
        public string TellTitle { get; set; }
        public AppUser User { get; set; }
    }
}
