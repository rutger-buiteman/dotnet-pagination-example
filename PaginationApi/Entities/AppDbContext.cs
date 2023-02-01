using Microsoft.EntityFrameworkCore;

namespace PaginationApi.Entities; 

public class AppDbContext: DbContext {
	public AppDbContext(DbContextOptions options) : base(options) { }
	
	public DbSet<User> Users { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		modelBuilder.Entity<User>().HasKey(p => p.Id);
		modelBuilder.Entity<User>().Property(p => p.Id).IsRequired().HasDefaultValueSql("NEWID()");
		modelBuilder.Entity<User>().Property(p => p.FirstName).IsRequired();
		modelBuilder.Entity<User>().Property(p => p.LastName).IsRequired();
		modelBuilder.Entity<User>().Property(p => p.Email).IsRequired();
		modelBuilder.Entity<User>().Property(p => p.Gender).IsRequired();
		modelBuilder.Entity<User>().Property(p => p.IpAddress).IsRequired();

		base.OnModelCreating(modelBuilder);
	}
}