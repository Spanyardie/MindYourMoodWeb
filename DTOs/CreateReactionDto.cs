namespace MindYourMoodWeb.DTOs
{
    public class CreateReactionDto
    {
        public string ToWhat { get; set; }
        public int Strength { get; set; } = 0;
        public int Type { get; set; }
        public int DoAction { get; set; }
        public string ActionOf { get; set; } = "";
        public int UserId { get; set; }
    }
}
