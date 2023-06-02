using Microsoft.EntityFrameworkCore;
using UsersApi.Data.Interfaces;
using UsersApi.Data.Repositories;
using UsersApi.Data;

namespace UsersApi;

public static class StartupHelperExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryDb"));

        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddTransient<DbSeeder>();


        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }        

        app.MapControllers();

        return app;
    }

    public static void SeedDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        try
        {
            var dbSeeder = scope.ServiceProvider.GetService<DbSeeder>();
            if (dbSeeder != null)
            {
                dbSeeder.Seed();
            }
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
            logger.LogError(ex, "An error occurred while seed the database.");
        }
    }
}
