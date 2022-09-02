using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MirrorLink.Application.Contracts.Persistence;
using MirrorLink.Domain.Entities;

namespace MirrorLink.Infrastructure
{
    internal class PetJsonRepository : IPetRepository
    {
        private readonly string _petLocation;

        public PetJsonRepository()
        {
            _petLocation = Path.Combine(Directory.GetCurrentDirectory(), "\\PetJSON.json");
        }

        public Task GetAsync(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        Task<Pet> IAsyncRepository<Pet>.AddAsync(Pet entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        Task IAsyncRepository<Pet>.DeleteAsync(Pet entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        Task<Pet> IAsyncRepository<Pet>.GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<Pet>> IAsyncRepository<Pet>.ListAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        Task IAsyncRepository<Pet>.UpdateAsync(Pet entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
