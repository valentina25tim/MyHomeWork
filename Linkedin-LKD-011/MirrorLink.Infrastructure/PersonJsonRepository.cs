using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MirrorLink.Application.Contracts.Persistence;
using MirrorLink.Domain.Entities;

namespace MirrorLink.Infrastructure
{
    internal class PersonJsonRepository : IPersonRepository
    {
        private readonly string _personLocation;

        public PersonJsonRepository()
        {
            _personLocation = Path.Combine(Directory.GetCurrentDirectory(), "\\PersonJSON.json");
        }

        public Task GetAsync(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        Task<Person> IAsyncRepository<Person>.AddAsync(Person entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        Task IAsyncRepository<Person>.DeleteAsync(Person entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        Task<Person> IAsyncRepository<Person>.GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<Person>> IAsyncRepository<Person>.ListAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        Task IAsyncRepository<Person>.UpdateAsync(Person entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
