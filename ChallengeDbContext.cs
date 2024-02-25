using London.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace London.Api;

public class ChallengeDbContext : DbContext
{
	public ChallengeDbContext(DbContextOptions<ChallengeDbContext> options) : base(options)
	{
	}

	// DbSet definition for Users table
	public DbSet<User> Users { get; set; }

	// DbSet definition for Books table
	public DbSet<Book> Books { get; set; }

	// Adjustments for database tables and relationships
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Necessary adjustments for the User table
		_ = modelBuilder.Entity<User>()
			.HasKey(u => u.Id); // Set the Id field as the primary key
								// You can make other User table adjustments here

		// Necessary settings for the Book table
		_ = modelBuilder.Entity<Book>()
			.HasKey(b => b.Id); // Set the Id field as the primary key
								// You can make other Book table adjustments here

		// Example to define the relationship between User and Book:
		// modelBuilder.Entity<User>()
		//     .HasMany(u => u.Books) // A user can have multiple books
		//     .WithOne(b => b.User) // Every book must have a user
		//     .HasForeignKey(b => b.UserId); // Establish relationship based on user ID
	}
}
