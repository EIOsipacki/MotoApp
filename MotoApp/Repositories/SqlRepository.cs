
using Microsoft.EntityFrameworkCore;
using MotoApp.Entities;

namespace MotoApp.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public IEnumerable<T> GetAll()
        {
            //return _dbSet.OrderBy(item => item.Id).ToList();
            //bez sortowania
            return _dbSet.ToList();
        }
            

        public SqlRepository(DbContext dbContext)
        {            
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public T? GetById(int id) 
        {
            return _dbSet.Find(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
