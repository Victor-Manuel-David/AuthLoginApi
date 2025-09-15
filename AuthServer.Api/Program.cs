using AuthServer.Application.Auth;
using AuthServer.Domain.Abstractions;
using AuthServer.Infrastructure.Auth;
using AuthServer.Infrastructure.Configuration;
using AuthServer.Infrastructure.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Serilog
builder.Host.UseSerilog((ctx, cfg) =>
{
    cfg.ReadFrom.Configuration(ctx.Configuration);
});

// Bind JwtOptions
var jwtOptions = new JwtOptions();
builder.Configuration.GetSection("Jwt").Bind(jwtOptions);
builder.Services.AddSingleton(jwtOptions);

//DI
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<IAuthService, JwtAuthService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSerilogRequestLogging();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
