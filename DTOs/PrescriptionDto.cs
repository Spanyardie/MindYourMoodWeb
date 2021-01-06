using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        [Required]
        public int MedicationId { get; set; }
        [Required]
        public int PrescriptionType { get; set; }
        public int WeeklyDay { get; set; } = 0;
        public int MonthlyDay { get; set; } = 0;
    }
}
