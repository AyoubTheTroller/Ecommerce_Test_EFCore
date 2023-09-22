using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Models;

namespace Ecommerce.Configurations{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>{
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(u => u.Id);
        }
    }
}