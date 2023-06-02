using UsersApi.Data.Entities;

namespace UsersApi.Data.Interfaces;

public interface IUserRepository : IRepository<User>
{
    // Métodos específicos para o repositório de usuários, se necessário

    IEnumerable<User> GetUsersOrderedByName();
    public IEnumerable<User> FindUsersByName(string name);

}
