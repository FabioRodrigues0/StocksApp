using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions options) : base(options)
	{
	}
}