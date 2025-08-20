using ISpire.Core.Repositories;
using ISpire.Core.Services;
using ISpire.Infrastructure.Contexts;
using ISpire.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var connectionStringPath = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

if (connectionStringPath == null)
{
    Console.WriteLine("Connection string is not found");
    return;
}

var connectionString = File.ReadAllText(connectionStringPath).Trim();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IAccountRepository, DbAccountRepository>();

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(connectionString));

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();