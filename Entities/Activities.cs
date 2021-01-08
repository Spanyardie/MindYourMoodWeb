using System;
using System.Collections.Generic;

namespace MindYourMoodWeb.Entities
{
    public class Activities
    {
        public int Id { get; set; }
        public DateTime ActivityDate { get; set; }
        public IEnumerable<ActivityTimes> ActivityTimes { get; set; }
        public AppUser User { get; set; }
    }
}
