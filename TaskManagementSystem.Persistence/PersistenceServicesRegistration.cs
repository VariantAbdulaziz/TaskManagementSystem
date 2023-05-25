using TaskManagementSystem.Persistence.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Contracts.Identity;
using TaskManagementSystem.Application.Contracts.Persitence;
using TaskManagementSystem.Application.Models.Identity;
using TaskManagementSystem.Domain;
using TaskManagementSystem.Persistence.Repositories;

namespace TaskManagementSystem.Persistence;
public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TaskManagementDbContext>(opt =>
        opt.UseNpgsql(configuration.GetConnectionString("TaskManagementDbConnection")));

        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TaskManagementDbContext>()
                .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration.GetValue<string>("JwtSettings:Issuer"),
                ValidAudience = configuration.GetValue<string>("JwtSettings:Audience"),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JwtSettings:Key")))
            };
        });

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICheckListRepository, CheckListRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();

        return services;
    }
}