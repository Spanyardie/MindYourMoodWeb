namespace MindYourMoodWeb.DTOs
{
    public class CreateImageDto
    {
        public string Uri { get; set; }
        public string Comment { get; set; } = "";
        public int UserId { get; set; }
    }
}
