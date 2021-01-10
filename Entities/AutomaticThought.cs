using System.Collections.Generic;

namespace MindYourMoodWeb.Entities
{
    public class AutomaticThought : Entity
    {
        //public int Id { get; set; }
        public bool HotThought { get; set; }
        public string Thought { get; set; }
        public ThoughtRecord ThoughtRecord { get; set; }
        public IEnumerable<EvidenceForHotThought> EvidenceForHotThought { get; set; }
        public IEnumerable<EvidenceAgainstHotThought> EvidenceAgainstHotThought { get; set; }
    }
}
