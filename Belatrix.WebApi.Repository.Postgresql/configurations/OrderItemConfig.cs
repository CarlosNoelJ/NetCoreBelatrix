using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.configurations
{
    internal class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_item")
                .HasKey(c => c.Id)
                .HasName("orderitem_id_pkey"); ;

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.UnitPrice)
                .HasColumnName("unit_price")
                .IsRequired();

            builder.Property(p => p.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.HasIndex(p => new { p.Id, p.OrderId })
                .HasName("orderItem_order_idx");

            builder.HasIndex(p => new { p.Id, p.ProductId })
                .HasName("orderItem_product_idx");
        }
    }
}
