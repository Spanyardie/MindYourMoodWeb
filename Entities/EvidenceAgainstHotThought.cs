﻿namespace MindYourMoodWeb.Entities
{
    public class EvidenceAgainstHotThought : Entity
    {
        //public int Id { get; set; }
        public AutomaticThought AutomaticThought { get; set; }
        public string Evidence { get; set; }
        public ThoughtRecord ThoughtRecord { get; set; }
    }
}
