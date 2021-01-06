using System.Collections.Generic;

namespace MindYourMoodWeb.Entities
{
    public class Prescription
    {
        public int Id { get; set; }
        public ICollection<Medication> Medications { get; set; }
        public int PrescriptionType { get; set; }
        public int WeeklyDay { get; set; }
        public int MonthlyDay { get; set; }
        public AppUser User { get; set; }
    }
}
