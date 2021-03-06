﻿using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        [Required]
        public int PrescriptionType { get; set; }
        public int WeeklyDay { get; set; } = 0;
        public int MonthlyDay { get; set; } = 0;
        public IEnumerable<Medication> Medications { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
