using Cambio_24.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cambio_24.Data.Mapping
{
    public class RateMap : IEntityTypeConfiguration<RateEntity>
    {
        public void Configure(EntityTypeBuilder<RateEntity> builder)
        {
            builder.ToTable("c24_rate");
            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Code).IsUnique();
            builder.Property(p => p.Code).IsRequired().HasMaxLength(3).HasColumnName("code");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30).HasColumnName("name");
            builder.Property(p => p.Symbol).IsRequired().HasMaxLength(3).HasColumnName("symbol");
            builder.Property(p => p.Balance).IsRequired().HasColumnName("balance");
            builder.Property(p => p.TaxRatePurchase).IsRequired().HasColumnName("tax_rate_purchase");
            builder.Property(p => p.TaxRateSales).IsRequired().HasColumnName("tax_rate_sales");
            builder.Property(p => p.TaxRate).IsRequired().HasColumnName("tax_rate");
            builder.Property(p => p.CreatedAt).HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");

        }
    }
}
