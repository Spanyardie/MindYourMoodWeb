namespace MindYourMoodWeb.Entities
{
    public class HotThought
    {
        public virtual int Id { get; set; }
        public AutomaticThought AutomaticThought { get; set; }
        public string Evidence { get; set; }
        public ThoughtRecord ThoughtRecord { get; set; }
    }
}
