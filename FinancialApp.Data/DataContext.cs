using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using FinacialApp.Domain.Models;

namespace FinacialApp.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	public DataContext()
	{
	}

	public DbSet<Document> Documents { get; set; }
	public DbSet<CashBook> CashBooks { get; set; }
	public DbSet<BuyRequest> BuyRequests { get; set; }
	public DbSet<BuyRequestProducts> BuyRequestProducts { get; set; }

	public static readonly ILoggerFactory ConsoleLoggerFactory
		= LoggerFactory.Create(builder => { builder.AddDebug(); });

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if(!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=FinancialApp;trusted_connection=true")
				.UseLoggerFactory(ConsoleLoggerFactory)
				.EnableSensitiveDataLogging();
		}
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<BuyRequest>()
			.HasKey("Id");
		modelBuilder.Entity<CashBook>()
			.HasKey("Id");
		modelBuilder.Entity<Document>()
			.HasKey("Id");
		modelBuilder.Entity<BuyRequestProducts>()
			.HasKey("Id");
	}
}

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
	public DataContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
		optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=FinancialApp;trusted_connection=true");

		return new DataContext(optionsBuilder.Options);
	}
}