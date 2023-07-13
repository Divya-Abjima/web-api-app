using WebApiAppdemo.Models;

namespace WebApiAppdemo
{
    public class DinosaurRepository
    {
        public List<DinosaurDto> Dinosaurs { get; set;}
        //public static DinosaurRepository Current { get; } = new DinosaurRepository();
        
        public DinosaurRepository() 
        {
            Dinosaurs = new List<DinosaurDto>()
            {
                new DinosaurDto()
                {
                    Id = 101,
                    Name = "Pterodactyl",
                    Description= "",
                    Age = new List<AgeDto>()
                    {  
                        new AgeDto()
                        {
                            AgeId = 1011,
                            Name= "Pterodactyl",
                            Age = "Late Jurassic to late creatceous epochs"
                        }
                    }
                },
                new DinosaurDto()
                 {
                    Id = 102,
                    Name = "Stegosaurus",
                    Description= "",
                     Age = new List<AgeDto>()
                    {
                        new AgeDto()
                        {

                            AgeId = 1021,
                            Name = "Stegosaurus",
                            Age = "Late Jurassic to late creatceous epochs"
                        }
                    }
                },
                 new DinosaurDto()
                 {
                    Id = 103,
                    Name = "Ankylosaurus",
                    Description= "",
                     Age = new List<AgeDto>()
                    {
                        new AgeDto()
                        {
                             AgeId = 1031,
                            Name = "Ankylosaurus",
                            Age = "Late Jurassic to late creatceous epochs"
                        }
                    }
                },
                  new DinosaurDto()
                 {
                    Id = 104,
                    Name = "T-Rex",
                    Description= "",
                     Age = new List<AgeDto>()
                    {
                        new AgeDto()
                        {
                            AgeId = 1041,
                            Name = "T-Rex",
                            Age = "Late Jurassic to late creatceous epochs"
                        }
                    }
                },
                   new DinosaurDto()
                 {
                    Id = 105,
                    Name = "Megalosaurus",
                    Description= "",
                     Age = new List<AgeDto>()
                    {
                        new AgeDto()
                        {
                            AgeId = 1051,
                            Name = "Megalosaurus",
                            Age = "Late Jurassic to late creatceous epochs"
                        }
                    }
                },
            };
        }
    }
}
