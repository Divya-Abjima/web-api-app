using System.ComponentModel.DataAnnotations;

namespace WebApiAppdemo.Models
{
    public class DinosaurUpdateDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [MaxLength(350)]
        public string? Description { get; set; }
    }
}
