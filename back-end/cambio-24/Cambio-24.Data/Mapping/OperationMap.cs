using Cambio_24.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Data.Mapping
{
    public class OperationMap : IEntityTypeConfiguration<OperationEntity>
    {
        public void Configure(EntityTypeBuilder<OperationEntity> builder)
        {
            builder.ToTable("c24_operation");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.OperationDate).HasColumnName("operation_date");
            builder.Property(p => p.OperationTypeId).IsRequired().HasColumnName("operation_type_id");
            builder.Property(p => p.CurrencyInputId).IsRequired().HasColumnName("currency_input_id");
            builder.Property(p => p.CurrencyOutputId).IsRequired().HasColumnName("currency_output_id");
            builder.Property(p => p.Description).IsRequired().HasMaxLength(30).HasColumnName("op_description");
            builder.Property(p => p.UserId).IsRequired().HasColumnName("userid");
            builder.Property(p => p.ClientId).IsRequired().HasColumnName("client_id");
            builder.Property(p => p.AmountReceived).IsRequired().HasColumnName("amount_recived");
            builder.Property(p => p.Amount).IsRequired().HasColumnName("amount");
            builder.Property(p => p.CreatedAt).HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");

            builder.HasOne(u => u.Client).WithMany().HasForeignKey(x => x.ClientId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(u => u.User).WithMany().HasForeignKey(x => x.UserId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(u => u.CurrencyInput).WithMany().HasForeignKey(x => x.CurrencyInputId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(u => u.CurrencyOutput).WithMany().HasForeignKey(x => x.CurrencyOutputId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(u => u.OperationType).WithMany().HasForeignKey(x => x.OperationTypeId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);

        }
    }
   
}
