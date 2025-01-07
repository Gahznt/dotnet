using Domain.Common;
using Domain.Interfaces;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;

public class BaseRepository<T>(AppDbContext context) : IBaseRepository<T>
    where T : BaseEntity
{
    public void Create(T entity)
    {
        entity.DateCreated = DateTimeOffset.UtcNow;
        context.Add(entity);
    }

    public void Update(T entity)
    {
        entity.DateUpdated = DateTimeOffset.UtcNow;
        context.Update(entity);
    }

    public void Delete(T entity)
    {
        entity.DateDeleted = DateTimeOffset.UtcNow;
        context.Remove(entity);
    }

    public async Task<T?> Get(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await context.Set<T>().ToListAsync(cancellationToken);
    }
}