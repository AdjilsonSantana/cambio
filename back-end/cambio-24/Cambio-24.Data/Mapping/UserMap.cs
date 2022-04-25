using Cambio_24.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cambio_24.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("c24_users");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasIndex(p => p.Username).IsUnique();
            builder.Property(p => p.Username).IsRequired().HasMaxLength(20).HasColumnName("username");
            builder.Property(p => p.Email).IsRequired().HasMaxLength(100).HasColumnName("email");
            builder.Property(p => p.Password).IsRequired().HasMaxLength(100).HasColumnName("password");
            builder.Property(p => p.Role).IsRequired().HasMaxLength(100).HasColumnName("role");
            builder.Property(p => p.Avatar).HasMaxLength(500).HasColumnName("avatar");
            builder.Property(p => p.LastAccessAt).HasColumnName("last_access_at");
            builder.Property(p => p.CreatedAt).HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
