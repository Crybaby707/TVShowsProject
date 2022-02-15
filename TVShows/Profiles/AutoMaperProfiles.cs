using AutoMapper;
using TVShows.BL.Dtos;
using TVShows.Domain;

namespace TVShows.WEB.Profiles;

public class AutoMaperProfiles : Profile
{
    public AutoMaperProfiles()
    {
        CreateMap<Content, CreateContentDto>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<UserHasRole, CreateUserHasRoleDto>().ReverseMap();
        CreateMap<UserShowList, AddUserShowListDto>().ReverseMap();
        CreateMap<User, AuthUserDto>().ReverseMap();
        CreateMap<Genre, CreateGenreDto>().ReverseMap();
        CreateMap<ContentGenre, CreateContentGenreDto>().ReverseMap();
    }
}

