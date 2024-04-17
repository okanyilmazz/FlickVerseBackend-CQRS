using Application.Features.Languages.Commands.Create;
using Application.Features.Languages.Commands.Delete;
using Application.Features.Languages.Commands.Update;
using Application.Features.Languages.Queries.GetById;
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

        CreateMap<UpdateLanguageCommand, Language>().ReverseMap();
        CreateMap<Language, UpdatedLanguageResponse>().ReverseMap();

        CreateMap<GetByIdLanguageQuery, Language>().ReverseMap();
        CreateMap<Language, GetByIdLanguageResponse>().ReverseMap();
    }
}
