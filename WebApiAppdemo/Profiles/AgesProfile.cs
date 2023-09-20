using AutoMapper;
namespace WebApiAppdemo.Profiles
{
    public class AgesProfile : Profile
    {
        public AgesProfile() {

            CreateMap<Entities.Ages, Models.AgeDto>();
        }
    }
}
