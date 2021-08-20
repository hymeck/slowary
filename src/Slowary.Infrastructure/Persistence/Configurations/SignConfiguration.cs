using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence.Configurations
{
    public class SignConfiguration : IEntityTypeConfiguration<Sign>
    {
        public void Configure(EntityTypeBuilder<Sign> builder)
        {
            builder
                .ToTable("sign")
                .HasCharSet("utf8mb4")
                .HasComment("represents sign in semiotic sense");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Id)
                .HasColumnName("sign_id")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasMaxLength(255)
                .HasComment("sign id");

            builder
                .Property(e => e.Value)
                .HasColumnName("value")
                .IsRequired()
                .HasMaxLength(255)
                .HasComment("sign value: 'Dog' (word), 'Zed is dead' (expression), 'Given enough eyeballs, all bugs are shallow.' (quote), etc");

            builder
                .Property(e => e.Semantics)
                .HasColumnName("semantics")
                .IsRequired(false)
                .HasMaxLength(255)
                .HasComment("sign meaning");

            builder
                .Property(e => e.Example)
                .HasColumnName("example")
                .IsRequired(false)
                .HasMaxLength(255)
                .HasComment("bright example of sign usage");

            builder
                .Property(e => e.Source)
                .HasColumnName("source")
                .IsRequired(false)
                .HasMaxLength(255)
                .HasComment("place where sign was found");

            builder
                .Property(e => e.Note)
                .HasColumnName("note")
                .IsRequired(false)
                .HasMaxLength(255)
                .HasComment("additional information associated with sign");

            builder
                .Property(e => e.Added)
                .HasColumnName("added")
                .HasColumnType("datetime")
                .IsRequired(false)
                .HasComment("when sign was added");
            
            builder
                .Property(e => e.Modified)
                .HasColumnName("modified")
                .HasColumnType("datetime")
                .IsRequired(false)
                .HasComment("when sign was added");
        }
    }
}