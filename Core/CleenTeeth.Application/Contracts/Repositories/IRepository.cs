namespace CleenTeeth.Application.Contracts.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> Add(T entity);
    Task Delete(T entity);
    Task Update(T entity);
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(Guid id);
}
