using DataAccess.Data.Enitites;
using DataAccess.Enitites;
using Microsoft.EntityFrameworkCore;

namespace App.Data;

public class DatabaseContext : DbContext
{
	public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
	{
	}

	public DbSet<Course> Courses { get; set; }
	public DbSet<CourseTopic> Topics { get; set; }
}
