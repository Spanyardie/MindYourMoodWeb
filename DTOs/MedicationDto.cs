using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class MedicationDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string MedicationName { get; set; }
        [Required]
        public int TotalDailyDosage { get; set; } = 0;
    }
}
