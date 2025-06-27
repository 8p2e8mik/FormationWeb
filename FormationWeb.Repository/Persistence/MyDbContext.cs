using FormationWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FormationWeb.Repository.Persistence;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    // public DbSet<UserDetails> UserDetails { get; set; }
    // public DbSet<Transaction> Transactions { get; set; }
}