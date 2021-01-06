namespace MindYourMoodWeb.Entities
{
    public class Situation
    {
        public int Id { get; set; }
        public ThoughtRecord ThoughtRecord { get; set; }
        public string Who { get; set; }
        public string What { get; set; }
        public string When { get; set; }
        public string Where { get; set; }
    }
}
