namespace WebApiAppdemo.Models
{
    public class DinosaurDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int TotalAges
        {
            get
            {
                return Age.Count;
            }
        } 

        public ICollection<AgeDto> Age { get; set; }= new List<AgeDto>();

    }
}
