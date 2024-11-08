using Microsoft.EntityFrameworkCore;
using ProjectWeb.Models;

namespace ProjectWeb.Data
{
	public class ApplicationDBContext:DbContext
	{
		public DbSet<Category> Categories { get; set; }
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Adventure",Description="Give you a feel of challenge",DisplayPriority = 1},
				new Category { Id = 2, Name = "Roman", Description = "So romantique", DisplayPriority = 4 },
				new Category { Id = 3, Name = "Horror", Description = "So scary", DisplayPriority = 3 },
				new Category { Id = 4, Name = "Scifi", Description = "So interesting", DisplayPriority = 2 }
				);

		}
	}
}
