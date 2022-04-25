using Cambio_24.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cambio_24.Data.Mapping
{
    public class OperationTypeMap : IEntityTypeConfiguration<OperationTypeEntity>
    {
        public void Configure(EntityTypeBuilder<OperationTypeEntity> builder)
        {
            builder.ToTable("c24_Operation_type");
            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Description).IsUnique(); 
            builder.HasIndex(p => p.Code).IsUnique();
            builder.Property(p => p.Code).IsRequired().HasMaxLength(1).HasColumnName("operation_code");
            builder.Property(p => p.Description).IsRequired().HasMaxLength(50).HasColumnName("operation_description");
            builder.Property(p => p.CreatedAt).HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
