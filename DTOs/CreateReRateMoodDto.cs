namespace MindYourMoodWeb.DTOs
{
    public class CreateReRateMoodDto
    {
        public int MoodListId { get; set; }
        public int MoodRating { get; set; } = 0;
        public int MoodsId { get; set; }
        public int ThoughtRecordId { get; set; }
    }
}
