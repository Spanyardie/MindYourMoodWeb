using System;

namespace MindYourMoodWeb.Entities
{
    public class ActivityTimes : Entity
    {
        public Activities Activity { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public DateTime Time { get; set; }
        public int Achievement { get; set; }
        public int Intimacy { get; set; }
        public int Pleasure { get; set; }
    }
}
