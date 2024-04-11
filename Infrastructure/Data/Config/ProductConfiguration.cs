using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        private int stringMaxLengthForName = 150;

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(prod => prod.Id).IsRequired();
            builder.Property(prod => prod.Name).IsRequired()
             .HasMaxLength(stringMaxLengthForName);
            builder.Property(prod => prod.Description).IsRequired();
            builder.Property(prod => prod.Price).IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(prod => prod.PictureURL);
            builder.HasOne(t => t.ProductBrand)
            .WithMany().HasForeignKey(x => x.ProductBrandId);
            builder.HasOne(prodtype => prodtype.ProductType).WithMany()
            .HasForeignKey(x => x.ProductTypeId);
        }
    }
}