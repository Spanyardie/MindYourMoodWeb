using System;
using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class MedicationTimeDto
    {
        public int Id { get; set; }
        [Required]
        public int SpreadId { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public DateTime TakenTime { get; set; }
    }
}
