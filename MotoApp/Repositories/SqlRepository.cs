
using Microsoft.EntityFrameworkCore;
using MotoApp.Entities;

public delegate void ItemAdded(object item);

namespace MotoApp.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        private readonly ItemAdded? _itemAddedCallback;

        public IEnumerable<T> GetAll()
        {
            //return _dbSet.OrderBy(item => item.Id).ToList();
            //bez sortowania
            return _dbSet.ToList();
        }
            

        public SqlRepository(DbContext dbContext, ItemAdded? itemAddedCallback = null)
        {            
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
            _itemAddedCallback = itemAddedCallback;
        }

        public T? GetById(int id) 
        {
            return _dbSet.Find(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            _itemAddedCallback?.Invoke(item);

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
