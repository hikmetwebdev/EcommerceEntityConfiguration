using BigonEcommerce.Models.Entities;
using BigonEcommerce.Models.Persistances.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.Property(m => m.Id).HasColumnType("int");
        builder.Property(m => m.Name).HasColumnType("varchar(100)").IsRequired();
        builder.Property(m => m.Details).HasColumnType("varchar(max)");
        builder.Property(m => m.Description).HasColumnType("varchar(max)");
        builder.Property(m => m.Rating).HasColumnType("int");
        builder.Property(m => m.Stock).HasColumnType("int");
        builder.Property(m => m.Price).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(m => m.Discount).HasColumnType("decimal(18,2)").IsRequired();

        builder.HasKey(m => m.Id);

        builder.ConfigureAsAudutible();
    }
}
