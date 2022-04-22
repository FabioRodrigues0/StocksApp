using FinacialApp.Domain.Models;
using FinancialApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialApp.Data.Configurations;

public class BuyRequestConfiguration : IEntityTypeConfiguration<BuyRequest>
{
	public void Configure(EntityTypeBuilder<BuyRequest> builder)
	{
		builder.HasKey(p => p.Id);

		builder.Property(p => p.Id).IsRequired();
		builder.Property(p => p.Code).IsRequired();
		builder.Property(p => p.Date).IsRequired();
		builder.Property(p => p.Client).IsRequired();
		builder.Property(p => p.ClientDescription).IsRequired();
		builder.Property(p => p.ClientEmail).IsRequired();
		builder.Property(p => p.ClientPhone).IsRequired();
		builder.Property(p => p.Status).IsRequired();
		builder.Property(p => p.Discount).HasColumnType("decimal(18,2)");
		builder.Property(p => p.ProductValor)
			.IsRequired()
			.HasColumnType("decimal(18,2)");
		builder.Property(p => p.Cost)
			.IsRequired()
			.HasColumnType("decimal(18,2)");
		builder.Property(p => p.TotalValor)
			.IsRequired()
			.HasColumnType("decimal(18,2)");
	}
}