using WebApiAppdemo.Entities;

namespace WebApiAppdemo.Services
{
    public interface IDinoaurDetailRepository
    {
        Task<IEnumerable<Dinosaur>> GetDinosaursAsync();
        Task<Dinosaur?> GetDinosaurAsync(int dinosaurId, bool hasAges);
        Task<IEnumerable<Ages>> GetAgesAsync(int dinosaurId);
        Task<Ages> GetDinosaurAgeAsync(int dinosaurId, int ageId);
    }
}
