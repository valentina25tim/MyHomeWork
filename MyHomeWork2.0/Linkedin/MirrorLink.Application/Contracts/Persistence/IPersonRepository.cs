using Microsoft.Domain.Entities;

namespace MirrorLink.Application.Contracts.Persistence
{
    public interface IPersonRepository : IAsyncRepository<Person>
    {
    }
}
