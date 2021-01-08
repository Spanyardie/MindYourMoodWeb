using System;
using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class ActivityDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime ActivityDate { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
