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
        public Task<IEnumerable<Ages>> GetAgesAsync(int dinosaurId)
        {
            throw new NotImplementedException();
        }

        public Task<Ages> GetDinosaurAgeAsync(int dinosaurId, int ageId)
        {
            throw new NotImplementedException();
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
    }
}
