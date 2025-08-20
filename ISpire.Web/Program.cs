using System.Diagnostics;
using ISpire.Core.Repositories;
using ISpire.Core.Services;
using ISpire.Infrastructure.Contexts;
using ISpire.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

if (connectionString == null)
{
    throw new InvalidOperationException("Database connection string environment variable (DB_CONNECTION_STRING) is not set.");
}

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