using Application.Features.Languages.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Languages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Language, CreatedLanguageResponse>().ReverseMap();
    }
}
