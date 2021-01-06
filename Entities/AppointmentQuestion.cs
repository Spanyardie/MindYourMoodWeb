namespace MindYourMoodWeb.Entities
{
    public class AppointmentQuestion
    {
        public int Id { get; set; }
        public Appointment Appointment { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
