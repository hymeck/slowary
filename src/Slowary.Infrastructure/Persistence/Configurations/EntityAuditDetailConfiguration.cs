using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence.Configurations
{
    public class EntityAuditDetailConfiguration : IEntityTypeConfiguration<SignAuditDetail>
    {
        public void Configure(EntityTypeBuilder<SignAuditDetail> builder)
        {
            builder
                .ToTable("audit_detail")
                .HasCharSet("utf8mb4")
                .HasComment("contains audit information associated with sign");

            builder
                .HasKey(e => e.Id);
            
            builder
                .Property(e => e.Id)
                .HasColumnName("audit_detail_id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(e => e.Added)
                .HasColumnName("added")
                .IsRequired()
                .HasComment("when sign was added");

            builder
                .Property(e => e.Modified)
                .HasColumnName("modified")
                .HasComment("when sign was modified");

            builder
                .Property(e => e.SignId)
                .HasColumnName("sign_id")
                .IsRequired()
                .HasComment("sign id");

            builder
                .HasIndex(e => e.SignId)
                .IsUnique()
                .HasDatabaseName("audit_detail_id_idx");
        }
    }
}