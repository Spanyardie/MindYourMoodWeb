﻿namespace MindYourMoodWeb.Entities
{
    public class GenericText : Entity
    {
        //public int Id { get; set; }
        public int TextType { get; set; }
        public string TextValue { get; set; }
        public AppUser User { get; set; }
    }
}
