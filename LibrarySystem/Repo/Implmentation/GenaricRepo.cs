using LibrarySystem.App_Context;
using LibrarySystem.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repo.Implmentation
{
    public class GenaricRepo<T>:IGenariceRepo<T> where T : class
    {
        protected readonly AppDbContext _context;
       protected readonly DbSet<T> _dbSet;
        public GenaricRepo(AppDbContext Context)
        {
            _context=Context;
            _dbSet = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
    }
}
