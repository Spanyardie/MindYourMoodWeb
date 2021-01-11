using System;

namespace MindYourMoodWeb.DTOs
{
    public class CreateThoughtRecordDto
    {
        public DateTime RecordDate { get; set; } = DateTime.Now;
        public int UserId { get; set; }
    }
}
