using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Models;

namespace Ecommerce.Configurations{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>{
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.User).WithMany().HasForeignKey(o => o.UserId).IsRequired();
        }
    }
}