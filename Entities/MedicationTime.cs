using System;

namespace MindYourMoodWeb.Entities
{
    public class MedicationTime
    {
        public int Id { get; set; }
        public MedicationSpread Spread { get; set; }
        public Medication Medication { get; set; }
        public DateTime Time { get; set; }
        public DateTime TakenTime { get; set; }
    }
}
