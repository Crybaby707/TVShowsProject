using AutoMapper;
using TVShows.BL.Dtos;
using TVShows.Domain;

namespace TVShows.WEB.Profiles
{
    public class AutoMaperProfiles : Profile
    {
        public AutoMaperProfiles()
        {
            CreateMap<Contents, CreateContentDto>().ReverseMap();
        }
    }
}
