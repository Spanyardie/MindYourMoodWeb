using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class AutomaticThoughtDto
    {
        public int Id { get; set; }
        public bool HotThought { get; set; }
        public string Thought { get; set; }
        [Required]
        public int ThoughtRecordid { get; set; }
    }
}
