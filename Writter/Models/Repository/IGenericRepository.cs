using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writter.ViewModels
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity item);
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }

    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        WritterModel _context;
        DbSet<TEntity> _dbSet;

        public EFGenericRepository(WritterModel context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(TEntity item)
        {
            _dbSet.Add(item);
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
        }
    }
}
