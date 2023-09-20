using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApiAppdemo.DBContexts;
using WebApiAppdemo.Entities;

namespace WebApiAppdemo.Services
{
    public class DinosaurDetailRepository : IDinoaurDetailRepository
    {
        private readonly DinosaurDetailContext _context;
        public DinosaurDetailRepository(DinosaurDetailContext dinosaurDetailContext)
        {
            _context = dinosaurDetailContext ?? throw new ArgumentNullException(nameof(dinosaurDetailContext));
        }
        public async Task<IEnumerable<Dinosaur>> GetAgesAsync(int dinosaurId)
        {
            return await _context.Dinosaurs.Include(d=>d.Age).ToListAsync();
        }

        public async Task<Ages> GetDinosaurAgeAsync(int dinosaurId, int ageId)
        {
            return await _context.Age.Where(c => (c.DinosaurId == dinosaurId && c.AgeId == ageId)).FirstOrDefaultAsync();
        }

        public async Task<bool> DinosaurExistsAsync(int dinosaurId)
        {
            return await _context.Dinosaurs.AnyAsync(d=> d.Id==dinosaurId);
        }
         
        public async Task<Dinosaur?> GetDinosaurAsync(int dinosaurId, bool hasAges)
        {
           if(hasAges)
            {
                return await _context.Dinosaurs.Include(c => c.Age)
                    .Where(d => d.Id == dinosaurId).FirstOrDefaultAsync();
            }
            return await _context.Dinosaurs
                    .Where(d => d.Id == dinosaurId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Dinosaur>> GetDinosaursAsync()
        {
            return await _context.Dinosaurs.ToListAsync();
        }
        public async Task AddDinosaurAsync(int Id, Dinosaur entry)
        {
            var dinosaur = await GetDinosaurAsync(Id, true);
            if(dinosaur!=null)
            {
              await _context.Dinosaurs.AddAsync(dinosaur);
               
            }
        }
        public async Task<bool> SaveChangesAsync()
         {
            return (await _context.SaveChangesAsync()>=0);
        }
    }
}
