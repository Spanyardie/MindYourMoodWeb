using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class RelationshipDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string ToWhat { get; set; }
        public int Strength { get; set; } = 0;
        public int Feeling { get; set; } = 0;
        [Required]
        public int Type { get; set; }
        [Required]
        public int DoAction { get; set; }
        [StringLength(200)]
        public string ActionOf { get; set; } = "";
    }
}
