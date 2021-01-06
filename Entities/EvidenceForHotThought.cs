namespace MindYourMoodWeb.Entities
{
    public class EvidenceForHotThought
    {
        public int Id { get; set; }
        public AutomaticThought AutomaticThought { get; set; }
        public string Evidence { get; set; }
        public ThoughtRecord ThoughtRecord { get; set; }
    }
}
