using TaskManagementSystem.Application.Contracts.Persitence;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Persistence.Repositories;

internal class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
{

    public TaskRepository(TaskManagementDbContext dbContext) : base(dbContext)
    {
    }
}
