using UsersApi.Data.Interfaces;

namespace UsersApi.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Rollback()
    {
        // Implemente aqui a lógica de rollback, se necessário
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}