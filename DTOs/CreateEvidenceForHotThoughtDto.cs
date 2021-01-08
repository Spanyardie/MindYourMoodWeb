namespace MindYourMoodWeb.DTOs
{
    public class CreateEvidenceForHotThoughtDto
    {
        public int AutomaticThoughtId { get; set; }
        public string Evidence { get; set; }
        public int ThoughtRecordId { get; set; }
    }
}
