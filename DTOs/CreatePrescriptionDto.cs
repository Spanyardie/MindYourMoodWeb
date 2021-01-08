using MindYourMoodWeb.Entities;
using System.Collections.Generic;

namespace MindYourMoodWeb.DTOs
{
    public class CreatePrescriptionDto
    {
        public int PrescriptionType { get; set; }
        public int WeeklyDay { get; set; } = 0;
        public int MonthlyDay { get; set; } = 0;
        public IEnumerable<Medication> Medications { get; set; }
        public int UserId { get; set; }
    }
}
