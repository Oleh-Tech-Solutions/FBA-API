using FamilyBudgeting.Application.Configuration;
using FamilyBudgeting.Application.Services;
using FamilyBudgeting.Application.Services.Interfaces;
using FamilyBudgeting.Domain.Core;
using FamilyBudgeting.Domain.Data.Ledgers;
using FamilyBudgeting.Domain.Data.Transactions;
using FamilyBudgeting.Domain.Data.UserLedgerRoles;
using FamilyBudgeting.Domain.Data.UserLedgers;
using FamilyBudgeting.Domain.Data.UserLedgersRoles;
using FamilyBudgeting.Domain.Data.Users;
using FamilyBudgeting.Infrastructure.Context;
using FamilyBudgeting.Infrastructure.JwtProviders;
using FamilyBudgeting.Infrastructure.Repositories;
using FamilyBudgeting.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddSingleton(resolver =>
    resolver.GetRequiredService<IOptions<JwtOptions>>().Value);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString(AppConstants.DBConnStringName)
    ?? throw new InvalidOperationException($"Connection string {AppConstants.DBConnStringName} not found.");

builder.Services.AddScoped<ISqlConnectionFactory>(x => new SqlConnectionFactory(connectionString));

var jwtOptions = builder.Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies[AppConstants.JwtCockieName];
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped<ILedgerRepository, LedgerRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IUserLedgerRepository, UserLedgerRepository>();
builder.Services.AddScoped<IUserLedgerRoleRepository, UserLedgerRoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
