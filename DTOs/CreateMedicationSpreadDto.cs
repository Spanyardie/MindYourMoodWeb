namespace MindYourMoodWeb.DTOs
{
    public class CreateMedicationSpreadDto
    {
        public int Dosage { get; set; }
        public int Relevance { get; set; }
        public int MedicationTimeId { get; set; }
        public int MedicationTakeReminderId { get; set; }
    }
}
