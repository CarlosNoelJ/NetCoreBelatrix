using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.configurations
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlSerialColumn();

            builder.Property(p => p.OrderDate)
                .HasColumnName("order_date")
                .IsRequired();

            builder.Property(p => p.OrderNumber)
                .HasColumnName("order_number")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.TotalAmount)
                .HasColumnName("total_amount")
                .IsRequired();

            builder.HasIndex(p => new { p.Id, p.OrderDate })
                .HasName("order_orderDate_idx");

            builder.HasIndex(p => new { p.Id, p.CustomerId})
                .HasName("order_customerId_idx");

            builder.Metadata.FindNavigation(nameof(Order.OrderItem))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(x => x.OrderItem).WithOne(o => o.Order)
                .HasForeignKey(c => c.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
