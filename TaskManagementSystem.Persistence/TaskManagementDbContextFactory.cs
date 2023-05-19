using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Persistence;
public class TaskManagementDbContextFactory : IDesignTimeDbContextFactory<TaskManagementDbContext>
{
    public TaskManagementDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<TaskManagementDbContext>();

        var connectionString = configuration.GetConnectionString("TaskManagementDbConnection");

        builder.UseNpgsql(connectionString);

        return new TaskManagementDbContext(builder.Options);
    }
}
