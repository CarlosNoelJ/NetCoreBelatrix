using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.configurations
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlSerialColumn();

            builder.Property(p => p.ProductName)
                .HasColumnName("product_name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.UnitPrice)
                .HasColumnName("unit_price")
                .IsRequired();

            builder.Property(p => p.Package)
                .HasColumnName("product_package")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.IsDiscontinued)
                .HasColumnName("product_discontinued")
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasIndex(p => new { p.Id, p.SupplierId })
                .HasName("product_supplier_idx");

            builder.HasIndex(p => p.ProductName)
                .HasName("product_name_idx");

            builder.Metadata.FindNavigation(nameof(Product.OrderItem))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(x => x.OrderItem).WithOne(o => o.Product)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
