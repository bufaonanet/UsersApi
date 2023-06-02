namespace UsersApi.Data.Interfaces;

public interface IUnitOfWork : IDisposable
{
    void Commit();
    void Rollback();
}
