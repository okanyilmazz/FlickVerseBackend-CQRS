using Application.Features.Languages.Commands.Create;
using Application.Features.Languages.Commands.Delete;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Languages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateLanguageCommand, Language>().ReverseMap();
        CreateMap<Language, CreatedLanguageResponse>().ReverseMap();

        CreateMap<DeleteLanguageCommand, Language>().ReverseMap();
        CreateMap<Language, DeletedLanguageResponse>().ReverseMap();
    }
}
