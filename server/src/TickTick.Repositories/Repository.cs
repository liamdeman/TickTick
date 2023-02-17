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
    
    public IQueryable<T> GetAll()
    {
        return _dbSet;
    }

    public async Task<int> AddAsync(T entity)
    {
        _dbContext.Add(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        await _dbSet.Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }
    
    public async Task<int> UpdateAsync(T entity)
    {
        _dbContext.Update(entity);
        return await _dbContext.SaveChangesAsync();
    }
}