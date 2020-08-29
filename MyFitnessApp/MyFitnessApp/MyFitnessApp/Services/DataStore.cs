using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyFitnessApp.Services
{
    public class DataStore<T> : IDataStore<T> where T : class, new()
    {
        private SQLiteAsyncConnection db_async;

        public DataStore(SQLiteAsyncConnection db)
        {
            this.db_async = db;
        }

        public AsyncTableQuery<T> AsQueryable() =>
            db_async.Table<T>();

        public async Task<List<T>> Get() =>
            await db_async.Table<T>().ToListAsync();

        public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = db_async.Table<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return await query.ToListAsync();
        }

        public async Task<T> Get(int id) =>
             await db_async.FindAsync<T>(id);

        public async Task<T> Get(Expression<Func<T, bool>> predicate) =>
            await db_async.FindAsync<T>(predicate);

        public async Task<int> Insert(T entity) =>
             await db_async.InsertAsync(entity);

        public async Task<int> Update(T entity) =>
             await db_async.UpdateAsync(entity);

        public async Task<int> Delete(T entity) =>
             await db_async.DeleteAsync(entity);
    }
}
