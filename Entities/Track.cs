namespace MindYourMoodWeb.Entities
{
    public class Track : Entity
    {
        public PlayList PlayList { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public int OrderNumber { get; set; }
        public string Uri { get; set; }
        public float Duration { get; set; }
    }
}
