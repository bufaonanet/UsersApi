using UsersApi.Data.Entities;
using UsersApi.Data.Interfaces;

namespace UsersApi.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context)
        : base(context) { }    

    // Implementação adicional de métodos específicos
    // para o repositório de usuários, se necessário

    public IEnumerable<User> GetUsersOrderedByName()
    {
        return _dbSet.OrderBy(u => u.Name).ToList();
    }

    public IEnumerable<User> FindUsersByName(string name)
    {
        return Find(u => u.Name.Contains(name));
    }
}
