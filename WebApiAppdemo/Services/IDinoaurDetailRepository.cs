using WebApiAppdemo.Entities;

namespace WebApiAppdemo.Services
{
    public interface IDinoaurDetailRepository
    {
        Task<IEnumerable<Dinosaur>> GetDinosaursAsync();
        Task<Dinosaur?> GetDinosaurAsync(int dinosaurId, bool hasAges);
        Task<IEnumerable<Dinosaur>> GetAgesAsync(int dinosaurId);
        Task<Ages> GetDinosaurAgeAsync(int dinosaurId, int ageId);
        Task<bool> DinosaurExistsAsync(int dinosaurId);
        Task AddDinosaurAsync(int Id, Dinosaur entry);
        Task<bool> SaveChangesAsync();
    }
}
