namespace MindYourMoodWeb.DTOs
{
    public class CreateTrackDto
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public int OrderNumber { get; set; } = 0;
        public string Uri { get; set; }
        public float Duration { get; set; } = 0.0f;
    }
}
