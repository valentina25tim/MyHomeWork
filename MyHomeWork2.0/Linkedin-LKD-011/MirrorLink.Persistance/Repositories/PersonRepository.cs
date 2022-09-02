using MirrorLink.Application.Contracts.Persistence;
using MirrorLink.Domain.Entities;

namespace MirrorLink.Persistence.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(MirrorLinkDbContext dbContext) : base(dbContext)
        {
        }

        //TODO here to add some specific queries
    }
}