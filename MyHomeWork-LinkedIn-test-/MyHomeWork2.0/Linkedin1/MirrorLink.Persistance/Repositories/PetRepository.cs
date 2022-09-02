using MirrorLink.Application.Contracts.Persistence;
using MirrorLink.Domain.Entities;

namespace MirrorLink.Persistence.Repositories
{
    public class PetRepository : BaseRepository<Pet>, IPetRepository
    {
        public PetRepository(MirrorLinkDbContext dbContext) : base(dbContext)
        {
        }

        //TODO here to add some specific queries
    }
}