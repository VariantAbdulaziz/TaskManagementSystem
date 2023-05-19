using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Contracts.Persitence;

namespace TaskManagementSystem.Persistence.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public readonly TaskManagementDbContext _dbContext;

    public GenericRepository(TaskManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<IReadOnlyList<T>> GetPagedAsync(int pageIndex, int pageSize)
    {
        return await _dbContext.Set<T>().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public virtual async Task<int> GetCountAsync()
    {
        return await _dbContext.Set<T>().CountAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}
