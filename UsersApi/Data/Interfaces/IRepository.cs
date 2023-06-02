using System.Linq.Expressions;

namespace UsersApi.Data.Interfaces;

public interface IRepository<T> where T : class
{
    IReadOnlyCollection<T> GetAll();
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    // Outros métodos de consulta, se necessário
}