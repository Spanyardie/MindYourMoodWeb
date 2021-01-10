namespace MindYourMoodWeb.Entities
{
    public class Mood : Entity
    {
        //public int Id { get; set; }
        public MoodList MoodList { get; set; }
        public int MoodRating { get; set; }
        public ThoughtRecord ThoughtRecord { get; set; }
    }
}
