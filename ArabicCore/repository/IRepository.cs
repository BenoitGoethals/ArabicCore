using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ArabicCore.model;

namespace ArabicCore.repository
{
    public interface IRepository<T>:IDisposable where  T:class 
    {
        IList<T> All();
        IList<T> All(Func<T, bool> predicate);
 
        T Add(T entity);
        void Update(T entity);
        void Insert(T item);
        T Update(T item, int id);
        void Delete(T item);
        IQueryable<T> Select();
        T Get(int id);
        Task<T> GetAsync(int id);
        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        int Count();
        Task<int> CountAsync()
    }
}