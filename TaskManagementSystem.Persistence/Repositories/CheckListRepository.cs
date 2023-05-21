using TaskManagementSystem.Application.Contracts.Persitence;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Persistence.Repositories;

internal class CheckListRepository : GenericRepository<CheckList>, ICheckListRepository
{

    public CheckListRepository(TaskManagementDbContext dbContext) : base(dbContext)
    {
    }
}