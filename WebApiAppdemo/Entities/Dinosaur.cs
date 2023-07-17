using WebApiAppdemo.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAppdemo.Entities
{
    public class Dinosaur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<AgeDto> Age { get; set; } = new List<AgeDto>();

        public Dinosaur(string name) 
        {
            Name = name;
        }
    }
}
