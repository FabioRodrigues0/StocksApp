using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.Domain.Models;

namespace Stock.Data.Configurations
{
	public class QueryProductsConfiguration : IEntityTypeConfiguration<ProductsMovement>
	{
		public void Configure(EntityTypeBuilder<ProductsMovement> builder)
		{
			builder.ToTable("QueryProductsMovement", "query");
			builder.HasKey(p => p.Id);

			builder.Property(p => p.Id).IsRequired();
			builder.Property(p => p.ProductId).IsRequired();
			builder.Property(p => p.ProductDescription).IsRequired();
			builder.Property(p => p.ProductCategory).IsRequired();
			builder.Property(p => p.ProductCategory).IsRequired();
			builder.Property(p => p.Quantity)
				.IsRequired()
				.HasColumnType("decimal(18,2)");
			builder.Property(p => p.ValorPerUnit)
				.IsRequired()
				.HasColumnType("decimal(18,2)");
			builder.Property(p => p.StorageId).IsRequired();
			builder.Property(p => p.StorageDescription).IsRequired();
		}
	}
}