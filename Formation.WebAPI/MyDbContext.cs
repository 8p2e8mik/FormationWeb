using Formation.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Formation.WebAPI;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserDetails> UserDetails { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure one-to-one relationship
        // modelBuilder.Entity<User>()
        //     .HasOne(u => u.Details)
        //     .WithOne(d => d.User)
        //     .HasForeignKey<UserDetails>(d => d.UserId)
        //     .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }

}