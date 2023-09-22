using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Models;

namespace Ecommerce.Configurations{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>{
        public void Configure(EntityTypeBuilder<Category> builder)
        {
             builder.HasKey(c => c.Id);
        }
    }
}