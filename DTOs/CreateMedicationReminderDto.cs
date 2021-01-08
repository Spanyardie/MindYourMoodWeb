using System;

namespace MindYourMoodWeb.DTOs
{
    public class CreateMedicationReminderDto
    {
        public int Id { get; set; }
        public int MedicationSpreadId { get; set; }
        public int MedicationDay { get; set; }
        public DateTime MedicationTime { get; set; }
    }
}
