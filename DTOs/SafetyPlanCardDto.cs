using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class SafetyPlanCardDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string CalmMyself { get; set; }
        [Required]
        [StringLength(300)]
        public string TellMyself { get; set; }
        [Required]
        [StringLength(300)]
        public string WillCall { get; set; }
        [Required]
        [StringLength(300)]
        public string WillGoTo { get; set; }
        public int UserId { get; set; }
    }
}
