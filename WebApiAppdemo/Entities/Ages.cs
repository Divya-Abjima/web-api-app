using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApiAppdemo.Entities
{
    public class Ages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;

        [ForeignKey("DinosaurId")]
        public Dinosaur? Dinosaur { get; set; }
        public int DinosaurId { get; set; }
        public Ages(string name) 
        {
            name = Name;
        }
    }
}
