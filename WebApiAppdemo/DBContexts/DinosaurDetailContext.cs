using Microsoft.EntityFrameworkCore;
using WebApiAppdemo.Entities;

namespace WebApiAppdemo.DBContexts
{
    public class DinosaurDetailContext : DbContext
    {
        public DbSet<Dinosaur> Dinosaurs { get; set;}
        public DbSet<Ages> Age { get; set;}
        public DinosaurDetailContext(DbContextOptions<DinosaurDetailContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dinosaur>().HasData(
                new Dinosaur("Pterodactyl")
                {
                    Id = 101,
                    Description = ""
                },
                 new Dinosaur("Stegosaurus")
                 {
                     Id = 102,
                     Description = ""
                 },
                  new Dinosaur("Ankylosaurus")
                  {
                      Id = 103,
                      Description = ""
                  },
                   new Dinosaur("T-Rex")
                   {
                       Id = 104,
                       Description = ""
                   },
                    new Dinosaur("Megalosaurus")
                    {
                        Id = 105,
                        Description = ""
                    }
                );
            modelBuilder.Entity<Ages>().HasData(
               new Ages("Pterodactyl")
               {
                   AgeId = 1011,
                   Age = "Late Jurassic to late creatceous epochs"
               },
                 new Ages("Stegosaurus")
                 {
                     AgeId = 1021,
                     Age = "Late Jurassic to late creatceous epochs"
                 },
                  new Ages("Ankylosaurus")
                  {
                      AgeId = 1031,
                      Age = "Late Jurassic to late creatceous epochs"
                  },
                   new Ages("T-Rex")
                   {
                       AgeId = 1041,
                       Age = "Late Jurassic to late creatceous epochs"
                   },
                    new Ages("Megalosaurus")
                    {
                        AgeId = 1051,
                        Age = "Late Jurassic to late creatceous epochs"
                    }
                ) ;
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionstr");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
