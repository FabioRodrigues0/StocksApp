using FinancialApp.Data.Configurations;
using FinancialApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace FinancialApp.Data;

public class DataContext : DbContext
{
	public static readonly ILoggerFactory ConsoleLoggerFactory
			= LoggerFactory.Create(builder => { builder.AddDebug(); });

	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	public DbSet<Document> Documents { get; set; }
	public DbSet<CashBook> CashBooks { get; set; }
	public DbSet<BuyRequest> BuyRequests { get; set; }
	public DbSet<BuyRequestProducts> BuyRequestProducts { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
			optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=FinancialApp;trusted_connection=true")
					.UseLoggerFactory(ConsoleLoggerFactory)
					.EnableSensitiveDataLogging();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new BuyRequestConfiguration()).Entity<BuyRequest>();
		modelBuilder.ApplyConfiguration(new BuyRequestProductConfiguration()).Entity<BuyRequestProducts>();
		modelBuilder.ApplyConfiguration(new CashBookConfiguration()).Entity<CashBook>();
		modelBuilder.ApplyConfiguration(new DocumentConfiguration()).Entity<Document>();
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