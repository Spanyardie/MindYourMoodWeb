﻿namespace MindYourMoodWeb.Entities
{
    public class TellMyself : Entity
    {
        //public int Id { get; set; }
        public string TellText { get; set; }
        public string TellTitle { get; set; }
        public AppUser User { get; set; }
    }
}
