using Cambio_24.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cambio_24.Data.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.ToTable("c24_client");
            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.TaxNumber).IsUnique();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50).HasColumnName("name");
            builder.Property(p => p.Email).HasMaxLength(50).HasColumnName("email");
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50).HasColumnName("lastname");
            builder.Property(p => p.Address).HasMaxLength(100).HasColumnName("address");
            builder.Property(p => p.BirthDate).IsRequired().HasColumnName("birthdate");
            builder.Property(p => p.Phonenumber).HasMaxLength(20).HasColumnName("phonenumber");
            builder.Property(p => p.TaxNumber).HasMaxLength(9).HasColumnName("taxnumber");
            builder.Property(p => p.DocNumber).IsRequired().HasMaxLength(20).HasColumnName("docnumber");
            builder.Property(p => p.DocumentTypeId).IsRequired().HasColumnName("document_type_id");
            builder.Property(p => p.EmployeeId).IsRequired().HasColumnName("employeeid");
            builder.Property(p => p.CreatedAt).HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");

            builder.HasOne(u => u.Employee).WithMany().HasForeignKey(x => x.EmployeeId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(u => u.DocumentType).WithMany().HasForeignKey(x => x.DocumentTypeId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
