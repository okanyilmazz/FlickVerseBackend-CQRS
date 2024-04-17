using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.Delete;

public class DeleteLanguageCommand : IRequest<DeletedLanguageResponse>
{
    public Guid Id { get; set; }

    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeletedLanguageResponse>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }


        public async Task<DeletedLanguageResponse> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            Language? language = await _languageRepository.GetAsync(predicate: l => l.Id == request.Id);

            await _languageRepository.DeleteAsync(language!);

            DeletedLanguageResponse response = _mapper.Map<DeletedLanguageResponse>(language);
            return response;
        }
    }
}