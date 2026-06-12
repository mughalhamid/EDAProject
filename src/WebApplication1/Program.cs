using Microsoft.EntityFrameworkCore;
using RedisApplication.Cache;
using RedisApplication.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// OpenAPI
builder.Services.AddOpenApi();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICacheService, CacheService>();
builder.Services.AddSingleton<ConnectionHelper>();

builder.Services.AddDbContext<RedisDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// In Development explicitly configure Kestrel endpoints so HTTPS port is bound
if (builder.Environment.IsDevelopment())
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        // HTTPS endpoint using the dev certificate
        options.ListenLocalhost(7111, listenOptions =>
        {
            listenOptions.UseHttps();
        });

        // HTTP endpoint
        options.ListenLocalhost(5099);
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();