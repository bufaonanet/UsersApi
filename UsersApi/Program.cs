using UsersApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

app.SeedDb();

app.Run();
