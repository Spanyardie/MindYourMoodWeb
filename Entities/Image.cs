namespace MindYourMoodWeb.Entities
{
    public class Image : Entity
    {
        //public int Id { get; set; }
        public string Uri { get; set; }
        public string Comment { get; set; }
        public AppUser User { get; set; }
    }
}
