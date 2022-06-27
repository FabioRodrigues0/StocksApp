using Infrastructure.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Stock.Data.Configurations;
using Stock.Domain.Models;

namespace Stock.Data
{
	public class MovementsContext : DataContext
	{
		public MovementsContext(DbContextOptions<MovementsContext> options) : base(options)
		{
		}

		public DbSet<Movements> Movements { get; set; }
		public DbSet<ProductsMovement> ProductsMovement { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new MovementsConfiguration()).Entity<Movements>();
			modelBuilder.ApplyConfiguration(new QueryMovementsConfiguration()).Entity<Movements>();
			modelBuilder.ApplyConfiguration(new ProductsMovementConfiguration()).Entity<ProductsMovement>();
			modelBuilder.ApplyConfiguration(new QueryProductsConfiguration()).Entity<ProductsMovement>();
		}
	}
}