using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UsersApi.Data.Interfaces;

namespace UsersApi.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    protected Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>(); 
    }
    public IReadOnlyCollection<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate).ToList();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }    

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    
}
