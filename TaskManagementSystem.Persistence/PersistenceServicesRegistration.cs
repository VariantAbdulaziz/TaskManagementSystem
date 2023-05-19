using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Contracts.Persitence;
using TaskManagementSystem.Persistence.Repositories;

namespace TaskManagementSystem.Persistence;
public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TaskManagementDbContext>(opt =>
        opt.UseNpgsql(configuration.GetConnectionString("TaskManagementDbConnection")));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICheckListRepository, CheckListRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();

        return services;
    }
}