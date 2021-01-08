using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class GenericTextDto
    {
        public int Id { get; set; }
        [Required]
        public int TextType { get; set; }
        [Required]
        [StringLength(300)]
        public string TextValue { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
