using CleenTeeth.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanTeeth.Persistence.Repositories;

public class Repository<T>(CleanTeethDbContext dbContext) : IRepository<T> where T : class
{
    public Task<T> Add(T entity)
    {
        dbContext.Add(entity);
        return Task.FromResult(entity);
    }

    public Task Delete(T entity)
    {
        dbContext.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await dbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetById(Guid id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }

    public Task Update(T entity)
    {
        dbContext.Update(entity);
        return Task.CompletedTask;
    }
}
