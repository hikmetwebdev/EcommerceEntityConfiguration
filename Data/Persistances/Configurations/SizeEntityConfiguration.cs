using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonEcommerce.Data.Persistances.Configurations
{
    public class SizeEntityConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(15);
            builder.Property(m => m.ShortName).HasColumnType("nvarchar").HasMaxLength(5);
        }
    }
}
