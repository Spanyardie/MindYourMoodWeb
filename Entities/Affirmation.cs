namespace MindYourMoodWeb.Entities
{
    public class Affirmation : Entity
    {
        public AppUser User { get; set; }
        public int UserId { get; set; }
        public string AffirmationText { get; set; }
    }
}
