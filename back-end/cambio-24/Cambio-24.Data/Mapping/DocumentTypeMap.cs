using Cambio_24.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cambio_24.Data.Mapping
{
    public class DocumentTypeMap : IEntityTypeConfiguration<DocumentTypeEntity>
    {
        public void Configure(EntityTypeBuilder<DocumentTypeEntity> builder)
        {
            builder.ToTable("c24_doc_type");
            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.DocTypeCode).IsUnique();
            builder.HasIndex(p => p.DocDescription).IsUnique();
            builder.Property(p => p.DocTypeCode).IsRequired().HasMaxLength(3).HasColumnName("doc_type_code");
            builder.Property(p => p.DocDescription).IsRequired().HasMaxLength(50).HasColumnName("doc_description");
            builder.Property(p => p.CreatedAt).HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
