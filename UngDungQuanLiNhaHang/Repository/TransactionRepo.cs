using Microsoft.EntityFrameworkCore.Storage;
using UngDungQuanLiNhaHang.Data;

namespace UngDungQuanLiNhaHang.Repository {
    public class TransactionRepo(DataDbConText _context) {
        private IDbContextTransaction? _transaction;
        public async Task BeginTransactionAsync() {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync() {
            if ( _transaction != null ) {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task RollbackAsync() {
            if ( _transaction != null ) {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task CompleteAsync() {
            await _context.SaveChangesAsync();
        }

    }
}
