using AutoMapper;
namespace WebApiAppdemo.Profiles
{
    public class DinosaurProfile : Profile
    {
        public DinosaurProfile() {
            CreateMap<Entities.Dinosaur, Models.DinosaurDto>(); /* <source, destination> */
            CreateMap<Models.DinosaurCreationDto, Entities.Dinosaur>();
        }
    }
}
