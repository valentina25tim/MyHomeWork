using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MirrorLink.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id, CancellationToken ct);
        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken ct);
        Task<T> AddAsync(T entity, CancellationToken ct);
        Task UpdateAsync(T entity, CancellationToken ct);
        Task DeleteAsync(T entity, CancellationToken ct);
        Task GetAsync(Func<object, bool> value);
    } 
}