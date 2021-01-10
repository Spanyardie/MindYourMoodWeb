namespace MindYourMoodWeb.Entities
{
    public class Affirmation : Entity
    {
        //public int Id { get; set; }
        public AppUser User { get; set; }
        public string AffirmationText { get; set; }
    }
}
