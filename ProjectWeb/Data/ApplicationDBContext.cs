using Microsoft.EntityFrameworkCore;
using ProjectWeb.Models;

namespace ProjectWeb.Data
{
	public class ApplicationDBContext:DbContext
	{
		public DbSet<Category> Categories { get; set; }
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
	}
}
