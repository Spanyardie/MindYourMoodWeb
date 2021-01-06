using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class MedicationSpreadDto
    {
        public int Id { get; set; }
        [Required]
        public int MedicationId { get; set; }
        public int Dosage { get; set; } = 0;
        public int Relevance { get; set; } = 2; //Magic number!!!
    }
}
