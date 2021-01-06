using System;
using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class MedicationReminderDto
    {
        public int Id { get; set; }
        [Required]
        public int MedicationSpreadId { get; set; }
        [Required]
        public int MedicationDay { get; set; }
        [Required]
        public DateTime MedicationTime { get; set; }
    }
}
