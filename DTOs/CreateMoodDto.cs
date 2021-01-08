namespace MindYourMoodWeb.DTOs
{
    public class CreateMoodDto
    {
        public int MoodListId { get; set; }
        public int MoodRating { get; set; } = 0;
        public int ThoughtRecordId { get; set; }
    }
}
