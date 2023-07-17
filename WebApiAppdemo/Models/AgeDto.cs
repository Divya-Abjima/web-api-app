using System.ComponentModel.DataAnnotations;

namespace WebApiAppdemo.Models
{
    public class AgeDto
    {
        [Key]
        public int AgeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
    }
}
