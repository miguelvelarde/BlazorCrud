using BlazorCrud.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>()
            .Property(b => b.CreationDate)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<Product>()
            .Property(p => p.ManufactureDate)
            .HasDefaultValueSql("GETUTCDATE()");
    }
}
