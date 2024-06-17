using PaulBot.Models;
using PaulBot.Modules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaulBot.Storage
{
  public class EfCoreStorage<T> : IStorage<T> where T : class
  {
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public EfCoreStorage(DbContext dbContext)
    {
      _dbContext = dbContext;
      _dbSet = _dbContext.Set<T>();
    }

    public async Task<T> ReadAsync(int id, CancellationToken cancellationToken = default)
    {
      return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
      _dbSet.Add(entity);
      await _dbContext.SaveChangesAsync(cancellationToken);
      return entity;
    }

    public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
      _dbContext.Entry(entity).State = EntityState.Modified;
      await _dbContext.SaveChangesAsync(cancellationToken);
      return entity;
    }

    public async Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
      _dbSet.Remove(entity);
      await _dbContext.SaveChangesAsync(cancellationToken);
      return entity;
    }
  }
}
