namespace MindYourMoodWeb.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public string Comment { get; set; }
        public AppUser User { get; set; }
    }
}
