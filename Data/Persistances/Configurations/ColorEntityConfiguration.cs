using BigonEcommerce.Data.Persistances.Configurations;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonEcommerce.Models.Persistances.Configurations
{
    public class ColorEntityConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(m=>m.Id).HasColumnType("int");
            builder.Property(m => m.Name).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.Property(m => m.HexCode).HasColumnType("varchar").HasMaxLength(7).IsRequired();


            builder.ConfigureAsAudutible();
            builder.HasKey(m => m.Id);
        }
    }
}
