namespace MindYourMoodWeb.Entities
{
    public class Mood
    {
        public int Id { get; set; }
        public int MoodList { get; set; }
        public int MoodRating { get; set; }
        public ThoughtRecord ThoughtRecord { get; set; }
    }
}
