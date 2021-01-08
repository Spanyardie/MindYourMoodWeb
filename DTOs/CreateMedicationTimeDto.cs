using System;

namespace MindYourMoodWeb.DTOs
{
    public class CreateMedicationTimeDto
    {
        public int SpreadId { get; set; }
        public DateTime Time { get; set; }
        public DateTime TakenTime { get; set; }
    }
}
