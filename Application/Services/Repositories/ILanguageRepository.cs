using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ILanguageRepository : IAsyncRepository<Language, Guid>, IRepository<Language, Guid>
{
}
