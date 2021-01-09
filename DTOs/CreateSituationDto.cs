namespace MindYourMoodWeb.DTOs
{
    public class CreateSituationDto
    {
        public int ThoughtRecordId { get; set; }
        public string Who { get; set; }
        public string What { get; set; }
        public string When { get; set; }
        public string Where { get; set; }
    }
}
