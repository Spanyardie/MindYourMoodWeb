using System;
using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class ThoughtRecordDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime RecordDate { get; set; } = DateTime.Now;
    }
}
