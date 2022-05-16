using CashBook.Data.Configurations;
using CashBook.Domain.Models;
using Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace CashBook.Data;

public class CashBookContext : DataContext
{
	public static readonly ILoggerFactory ConsoleLoggerFactory
			= LoggerFactory.Create(builder => { builder.AddDebug(); });

	public CashBookContext(DbContextOptions<CashBookContext> options) : base(options)
	{
	}

	public DbSet<CashBooks> CashBooks { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new CashBookConfiguration()).Entity<CashBooks>();
	}
}