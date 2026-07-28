using CleenTeeth.Application.Contracts.Persistence;

namespace CleanTeeth.Persistence.UnitsOfWork;

public class UnitOfWorkEFCore(CleanTeethDbContext dbContext) : IUnitOfWork
{
    public async Task Commit()
    {
        await dbContext.SaveChangesAsync();
    }

    public Task Rollback()
    {
        return Task.CompletedTask;
    }
}
