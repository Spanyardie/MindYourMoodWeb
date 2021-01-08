using System;

namespace MindYourMoodWeb.DTOs
{
    public class CreateActivityTimeDto
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public DateTime Time { get; set; }
        public int Achievement { get; set; } = 0;
        public int Intimacy { get; set; } = 0;
        public int Pleasure { get; set; } = 0;
    }
}
