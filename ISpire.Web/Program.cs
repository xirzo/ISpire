using ISpire.IO.Contexts;
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

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.Run();