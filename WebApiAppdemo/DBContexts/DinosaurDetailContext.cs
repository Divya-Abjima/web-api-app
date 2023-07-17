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
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionstr");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
