using TickTick.Models;

namespace TickTick.Repositories.Base;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    Task<int> SaveAsync();
}