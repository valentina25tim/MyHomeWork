using MirrorLink.Application.Contracts.Persistence;
using MirrorLink.Domain.Entities;

namespace MirrorLink.Persistence.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(MirrorLinkDbContext dbContext) : base(dbContext)
        {
        }

        //TODO here to add some specific queries
    }

}
