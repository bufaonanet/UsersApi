using Bogus;
using UsersApi.Data.Entities;

namespace UsersApi.Data;

public class DbSeeder
{
    private readonly ApplicationDbContext _context;

    public DbSeeder(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        if (!_context.Users.Any())
        {
            var faker = new Faker();

            for (int i = 1; i <= 10; i++)
            {
                var user = new User
                {
                    Id = i,
                    Name = faker.Name.FullName(),
                    Email = faker.Internet.Email()
                };

                _context.Users.AddRange(user);

            }                       
            _context.SaveChanges();
        }
    }
}
