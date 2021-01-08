namespace MindYourMoodWeb.DTOs
{
    public class CreateMedicationDto
    {
        public string MedicationName { get; set; }
        public int TotalDailyDosage { get; set; } = 0;
        public int PrescriptionId { get; set; }
    }
}
