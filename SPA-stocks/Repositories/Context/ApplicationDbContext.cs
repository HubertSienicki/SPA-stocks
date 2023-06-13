using Microsoft.EntityFrameworkCore;
using SPA_stocks.Models;

namespace SPA_stocks.Repositories.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Data Source=localhost,1433;Initial Catalog=master;User ID=sa;Password=Bo27erer#;TrustServerCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            // Set the table name for the User entity
            entity.ToTable("Users");

            // Customize property configurations
            entity.Property(u => u.Id).IsRequired();

            entity.Property(u => u.Email).IsRequired().HasMaxLength(100);

            entity.Property(u => u.Password).IsRequired();

            entity.Property(u => u.CreatedAt).IsRequired();
        });
    }
}