using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Models;

namespace Ecommerce.Configurations{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>{
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products) 
                   .HasForeignKey(p => p.categoryId);
        }
    }
}