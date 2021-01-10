using System.Collections.Generic;

namespace MindYourMoodWeb.Entities
{
    public class Medication : Entity
    {
        //public int Id { get; set; }
        public string MedicationName { get; set; }
        public int TotalDailyDosage { get; set; }
        public Prescription Prescription { get; set; }
        public ICollection<MedicationSpread> MedicationSpreads { get; set; }
    }
}
