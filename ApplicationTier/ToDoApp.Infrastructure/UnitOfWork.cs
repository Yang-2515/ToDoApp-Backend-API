using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ToDoApp.Domain.Interfaces;

namespace ToDoApp.Infrastructure
{
	public class UnitOfWork : IUnitOfWork
	{
		public DbFactory _dbFactory { get; private set; }
        //private Dictionary<string, object> Repositories { get; }
        private IDbContextTransaction _transaction;
        private IsolationLevel? _isolationLevel;

        public UnitOfWork(DbFactory dbFactory)
		{
			_dbFactory = dbFactory;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return await _dbFactory.DbContext.SaveChangesAsync(cancellationToken);
		}

		private async Task StartNewTransactionIfNeeded()
        {
            if (_transaction == null)
            {
                _transaction =  _isolationLevel.HasValue ?
                    await _dbFactory.DbContext.Database.BeginTransactionAsync(_isolationLevel.GetValueOrDefault()) : await _dbFactory.DbContext.Database.BeginTransactionAsync();
            }
        }

        public async Task BeginTransaction()
        {
            await StartNewTransactionIfNeeded();
        }

        public async Task CommitTransaction()
        {
            /*
             do not open transaction here, because if during the request
             nothing was changed(only select queries were run), we don't
             want to open and commit an empty transaction -calling SaveChanges()
             on _transactionProvider will not send any sql to database in such case
            */
            await _dbFactory.DbContext.SaveChangesAsync();

            if (_transaction == null) return;
            await _transaction.CommitAsync();

            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public async Task RollbackTransaction()
        {
            if (_transaction == null) return;

            await _transaction.RollbackAsync();

            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
}
