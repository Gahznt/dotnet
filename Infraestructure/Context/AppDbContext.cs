using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; init; }
}