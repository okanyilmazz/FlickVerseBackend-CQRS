using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.Create;

public class CreateLanguageCommand : IRequest<CreatedLanguageResponse>
{
    public string Name { get; set; }

    public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, CreatedLanguageResponse>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;


        public CreateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<CreatedLanguageResponse> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            Language language = _mapper.Map<Language>(request);

            await _languageRepository.AddAsync(language);

            CreatedLanguageResponse response = _mapper.Map<CreatedLanguageResponse>(language);
            return response;
        }
    }
}
