using System.Diagnostics;
using System.Text;
using ISpire.Core.Helpers;
using ISpire.Core.Repositories;
using ISpire.Core.Services;
using ISpire.Infrastructure.Contexts;
using ISpire.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
    
    if (string.IsNullOrWhiteSpace(connectionString))
    {
        throw new InvalidOperationException("DB_CONNECTION_STRING not set.");
    }
    
    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IAccountRepository, DbAccountRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        var jwtKey = EnvironmentHelper.GetEnvironmentVariableOrFile("JWT_KEY");
        var jwtIssuer = EnvironmentHelper.GetEnvironmentVariableOrFile("JWT_ISSUER");
        var jwtAudience = EnvironmentHelper.GetEnvironmentVariableOrFile("JWT_AUDIENCE");

        Debug.Assert(jwtKey != null, nameof(jwtKey) + " != null");
        Debug.Assert(jwtIssuer != null, nameof(jwtKey) + " != null");
        Debug.Assert(jwtAudience != null, nameof(jwtKey) + " != null");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddOpenApi();
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