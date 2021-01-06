namespace MindYourMoodWeb.Entities
{
    public class Affirmation
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public string AffirmationText { get; set; }
    }
}
