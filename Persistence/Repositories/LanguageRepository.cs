using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LanguageRepository : EfRepositoryBase<Language, Guid, BaseDbContext>, ILanguageRepository
{
    public LanguageRepository(BaseDbContext context) : base(context)
    {
    }
}
