using System;
using System.Collections.Generic;

namespace MindYourMoodWeb.Entities
{
    public class ThoughtRecord : Entity
    {
        public DateTime RecordDate { get; set; }
        public AppUser User { get; set; }
        public ICollection<Situation> Situation { get; set; }
        public ICollection<Mood> Moods { get; set; }
        public ICollection<AutomaticThought> AutomaticThoughts { get; set; }
        public ICollection<EvidenceForHotThought> EvidenceFor { get; set; }
        public ICollection<EvidenceAgainstHotThought> EvidenceAgainst { get; set; }
        public ICollection<AlternativeThought> AlternativeThoughts { get; set; }
        public ICollection<ReRateMood> ReRateMoods { get; set; }
    }
}
