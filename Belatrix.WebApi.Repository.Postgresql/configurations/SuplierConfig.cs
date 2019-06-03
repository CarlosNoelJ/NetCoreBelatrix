using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.configurations
{
    internal class SuplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("supplier")
                .HasKey(c => c.Id)
                .HasName("supplier_id_pkey"); ;

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.CompanyName)
                .HasColumnName("company_name")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(p => p.ContactName)
                .HasColumnName("contac_name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.ContactTitle)
                .HasColumnName("contact_title")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(p => p.City)
                .HasColumnName("city")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(p => p.Country)
                .HasColumnName("country")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(p => p.Phone)
                .HasColumnName("phone")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.Fax)
                .HasColumnName("fax")
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(p => p.ContactName)
                .HasName("contact_name_idx");

            builder.HasIndex(p => p.Country)
                .HasName("country");

            builder.Metadata.FindNavigation(nameof(Supplier.Product))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(x => x.Product).WithOne(c => c.Supplier)
                .HasForeignKey(b => b.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
