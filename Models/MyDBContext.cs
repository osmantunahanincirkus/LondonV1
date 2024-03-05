using London.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace London.Api.Models;

public class MyDBContext : DbContext
{
    public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
    {
    }

    public DbSet<Users> Users { get; init; }
    public DbSet<Books> Books { get; init; }
    public DbSet<UsersToBooks> UsersToBooks { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<User>().ToTable("Users");
        //modelBuilder.Entity<Book>().ToTable("Books");
        modelBuilder.Entity<UsersToBooks>()
            .HasKey(bc => new { bc.BookId, bc.UserId });
        modelBuilder.Entity<UsersToBooks>()
            .HasOne(bc => bc.Book)
            .WithMany(b => b.UsersToBooks)
            .HasForeignKey(bc => bc.BookId);
        modelBuilder.Entity<UsersToBooks>()
            .HasOne(bc => bc.User)
            .WithMany(c => c.UsersToBooks)
            .HasForeignKey(bc => bc.UserId);
    }
}