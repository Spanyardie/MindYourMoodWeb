namespace MindYourMoodWeb.DTOs
{
    public class CreateSafetyPlanCardDto
    {
        public string CalmMyself { get; set; }
        public string TellMyself { get; set; }
        public string WillCall { get; set; }
        public string WillGoTo { get; set; }
        public int UserId { get; set; }
    }
}
