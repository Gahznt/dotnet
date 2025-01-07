using Domain.Interfaces;
using Infraestructure.Context;

namespace Infraestructure.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task Commit(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}