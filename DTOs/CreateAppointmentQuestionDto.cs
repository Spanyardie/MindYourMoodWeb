namespace MindYourMoodWeb.DTOs
{
    public class CreateAppointmentQuestionDto
    {
        public int AppointmentId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; } = "";
    }
}
