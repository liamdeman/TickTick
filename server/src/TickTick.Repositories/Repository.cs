using Microsoft.EntityFrameworkCore;
using TickTick.Data;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly TickTickDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public Repository(TickTickDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public void Add(T entity)
    {
        _dbContext.Add(entity);
    }

    public void Delete(T entity)
    {
        _dbContext.Remove(entity);
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet;
    }

    public Task<int> SaveAsync()
    {
        return _dbContext.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _dbContext.Update(entity);
    }
}