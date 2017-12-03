using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ArabicCore.model;
using ArabicCore.Properties;

namespace ArabicCore.repository
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {

        private ArabicContext _ctx;

        protected DbSet<T> dbSet;


        public Repository(ArabicContext arabicContext)
        {
            _ctx = arabicContext;
            dbSet = _ctx.Set<T>();
        }


        public IList<T> All()
        {
           return _ctx.Set<T>().ToList<T>();
        }

        public IList<T> All(Func<T, bool> predicate)
        {
            return _ctx.Set<T>().Where(predicate).ToList<T>();
        }

        public void Insert(T item)
        {
            dbSet.Add(item);
        }

        public T Update(T item, int id)
        {
            if (item == null)
                return null;

            T existing = dbSet.Find(id);

            if (existing != null)
            {
                _ctx.Entry(existing).CurrentValues.SetValues(item);
            }
            return existing;
        }

        public void Delete(T item)
        {
            dbSet.Remove(item);
        }

        public IQueryable<T> Select()
        {
            return dbSet;
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _ctx.Set<T>().SingleOrDefault(match);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _ctx.Set<T>().SingleOrDefaultAsync(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _ctx.Set<T>().Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _ctx.Set<T>().Where(match).ToListAsync();
        }

        public int Count()
        {
            return dbSet.Count();
        }

        public Task<int> CountAsync()
        {
            return dbSet.CountAsync();
        }

        public T Add(T entity)
        {
            return _ctx.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
             _ctx.Entry(entity).State = EntityState.Modified;
            
        }

       //IDisposable implementation
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}