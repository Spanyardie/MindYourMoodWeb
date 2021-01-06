﻿using System.Collections.Generic;

namespace MindYourMoodWeb.Entities
{
    public class MedicationSpread
    {
        public enum FoodRelevance
        {
            Before,
            After,
            With,
            DoesntMatter
        }

        public int Id { get; set; }
        public Medication Medication { get; set; }
        public int Dosage { get; set; }
        public FoodRelevance Relevance { get; set; }
        public ICollection<MedicationTime> MedicationTimes { get; set; }
    }
}