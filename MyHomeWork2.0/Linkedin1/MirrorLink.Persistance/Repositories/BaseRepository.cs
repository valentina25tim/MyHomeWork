using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MirrorLink.Application.Contracts.Persistence;

namespace MirrorLink.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T>, IDisposable  where T : class
    {
        protected readonly MirrorLinkDbContext _dbContext;
        bool _disposed = false;

        public BaseRepository(MirrorLinkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id, CancellationToken ct)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken ct)
        {
            return await _dbContext.Set<T>().ToListAsync(ct);
        }

        public Task<T> AddAsync(T entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }                                                       
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if(disposing)
                _dbContext.Dispose();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task GetAsync(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}