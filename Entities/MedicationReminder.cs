using System;

namespace MindYourMoodWeb.Entities
{
    public class MedicationReminder : Entity
    {
        //public int Id { get; set; }
        public MedicationSpread MedicationSpread { get; set; }
        public int MedicationDay { get; set; }
        public DateTime MedicationTime { get; set; }
    }
}
