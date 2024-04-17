using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Queries.GetById;

public class GetByIdLanguageQuery : IRequest<GetByIdLanguageResponse>
{
    public Guid Id { get; set; }


    public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, GetByIdLanguageResponse>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public GetByIdLanguageQueryHandler(IMapper mapper, ILanguageRepository languageRepository)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
        }

        public async Task<GetByIdLanguageResponse> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
        {
            Language language = await _languageRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);

            GetByIdLanguageResponse response = _mapper.Map<GetByIdLanguageResponse>(language);
            return response;
        }
    }
}
