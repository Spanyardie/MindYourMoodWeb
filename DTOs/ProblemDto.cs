using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class ProblemDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(400)]
        public string ProblemText { get; set; }
    }
}
