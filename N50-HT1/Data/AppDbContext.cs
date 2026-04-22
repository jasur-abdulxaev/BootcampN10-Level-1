using Microsoft.EntityFrameworkCore;
using N50_HT1.Models.Entities;

namespace N50_HT1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Order> Orders => Set<Order>();
}