using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.Domain.Entities;

namespace Stock.Data.Configurations
{
	public class MovementsConfiguration : IEntityTypeConfiguration<Movements>
	{
		public void Configure(EntityTypeBuilder<Movements> builder)
		{
			builder.HasKey(p => p.Id);

			builder.Property(p => p.Id).IsRequired();
			builder.Property(p => p.Origin);
			builder.Property(p => p.OriginId);
			builder.Property(p => p.Date).IsRequired();
			builder.Property(p => p.Type).IsRequired();

			builder.HasMany(w => w.ProductsMovements)
				.WithOne(w => w.Movements)
				.HasForeignKey(f => f.MovementsId)
				.HasConstraintName("FK_ProductsMovements_MovementsId_Movements_Id");
		}
	}
}