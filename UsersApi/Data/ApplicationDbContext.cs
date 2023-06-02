using Microsoft.EntityFrameworkCore;
using UsersApi.Data.Entities;

namespace UsersApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações adicionais do modelo, se necessário
        base.OnModelCreating(modelBuilder);
    }
}
