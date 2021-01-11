namespace MindYourMoodWeb.DTOs
{
    public class CreateAlternativeThoughtDto
    {
        public string Alternative { get; set; }
        public int BeliefRating { get; set; } = 0;
        public int ThoughtRecordId { get; set; }
    }
}
