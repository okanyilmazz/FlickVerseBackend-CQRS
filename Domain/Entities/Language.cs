using Core.Persistence.Entities;

namespace Domain.Entities;

public class Language : Entity<Guid>
{
    public string Name { get; set; }
}
