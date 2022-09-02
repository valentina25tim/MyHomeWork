using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Domain.Repositories
{
    public interface IUnitOfWorks
    { 
        /// <summary>Saves the changes.</summary>
      /// <returns>The rows affected count.</returns>
        int SaveChanges();

        /// <summary>Saves the changes asynchronous.</summary>
        /// <returns>The rows affected count.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void AddOnSavedAction(Action action);
        void AddOnSavedAction(Func<Task> action);
        void AddOnSavingAction(Action action);
        void AddOnSavingAction(Func<Task> action);

        void AddOnSavedAction(string key, Action action);
        void AddOnSavedAction(string key, Func<Task> action);
        void AddOnSavingAction(string key, Action action);
        void AddOnSavingAction(string key, Func<Task> action);

        void SetChanged<TEntity>(params TEntity[] entities);
        void SetChanged<TEntity>(IEnumerable<TEntity> entities);

        /// <summary>Commits the transaction.</summary>
        void Commit();

        /// <summary>Cancels the transaction.</summary>
        void Rollback();

        void Remove<TEntity>(TEntity entity) where TEntity : class;

    }
}
