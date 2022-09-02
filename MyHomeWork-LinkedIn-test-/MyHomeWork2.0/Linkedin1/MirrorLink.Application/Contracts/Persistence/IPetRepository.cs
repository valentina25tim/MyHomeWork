using MirrorLink.Domain.Entities;

namespace MirrorLink.Application.Contracts.Persistence
{
    public interface IPetRepository : IAsyncRepository<Pet>
    {
    }
}