using System;

namespace MindYourMoodWeb.Entities
{
    public class Activities
    {
        public int Id { get; set; }
        public DateTime ActivityDate { get; set; }
        public AppUser User { get; set; }
    }
}
