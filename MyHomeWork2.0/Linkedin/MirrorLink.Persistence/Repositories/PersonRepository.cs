using Microsoft.Domain.Entities;
using MirrorLink.Application.Contracts.Persistence;

namespace MirrorLink.Persistence.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {  
        //TODO here to add some specific queries
        public PersonRepository(MirrorLinkDbContext dbContext) : base(dbContext)
        {
        }
    }
}
