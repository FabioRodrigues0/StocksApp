using FinancialApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialApp.Data.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Number).IsRequired();
        builder.Property(p => p.Date).IsRequired();
        builder.Property(p => p.DocumentType).IsRequired();
        builder.Property(p => p.Operation).IsRequired();
        builder.Property(p => p.Paid).IsRequired();
        builder.Property(p => p.PaymentDate).IsRequired();
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Observation).IsRequired();
        builder.Property(p => p.Total)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
    }
}