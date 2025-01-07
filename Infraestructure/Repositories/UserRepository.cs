using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    private readonly AppDbContext _context = context;

    public async Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x != null && x.Email == email, cancellationToken);
    }
}