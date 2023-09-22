using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Models;

namespace Ecommerce.Configurations{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetail>{
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
             builder.HasKey(od => od.Id);

            builder.HasOne(od => od.Order)
                   .WithMany(o => o.OrderDetails) 
                   .HasForeignKey(od => od.orderId);

            builder.HasOne(od => od.Product)
                   .WithMany(p => p.OrderDetails)
                   .HasForeignKey(od => od.productId); 
        }
    }
}