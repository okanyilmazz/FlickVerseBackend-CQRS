using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.Update;

public class UpdateLanguageCommand : IRequest<UpdatedLanguageResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdatedLanguageResponse>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public UpdateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }


        public async Task<UpdatedLanguageResponse> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            Language language = await _languageRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);

            language = _mapper.Map(request, language);
            await _languageRepository.UpdateAsync(language);

            UpdatedLanguageResponse response = _mapper.Map<UpdatedLanguageResponse>(language);
            return response;
        }
    }

}
