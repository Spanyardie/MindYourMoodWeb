using System;
using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Type { get; set; }
        public string Location { get; set; } = "";
        public string WithWhom { get; set; } = "";
        [Required]
        public DateTime AppointmentTime { get; set; }
        public string Notes { get; set; } = "";
        [Required]
        public int UserId { get; set; }
    }
}
