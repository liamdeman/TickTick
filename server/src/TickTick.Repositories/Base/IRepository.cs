using TickTick.Models;

namespace TickTick.Repositories.Base;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    Task<int> AddAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}