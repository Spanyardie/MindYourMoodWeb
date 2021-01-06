namespace MindYourMoodWeb.Entities
{
    public class ReRateMood
    {
        public int Id { get; set; }
        public int MoodListId { get; set; }
        public int MoodRating { get; set; }
        public Mood Mood { get; set; }
        public ThoughtRecord ThoughtRecord { get; set; }
    }
}
