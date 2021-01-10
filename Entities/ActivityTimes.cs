using System;

namespace MindYourMoodWeb.Entities
{
    public class ActivityTimes : Entity
    {
        //public int Id { get; set; }
        public Activities Activity { get; set; }
        public string ActivityName { get; set; }
        public DateTime Time { get; set; }
        public int Achievement { get; set; }
        public int Intimacy { get; set; }
        public int Pleasure { get; set; }
    }
}
