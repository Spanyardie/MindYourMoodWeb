using System;

namespace MindYourMoodWeb.DTOs
{
    public class CreateAppointmentDto
    {
        public DateTime Date { get; set; }
        public int Type { get; set; }
        public string Location { get; set; }
        public string WithWhom { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
    }
}
