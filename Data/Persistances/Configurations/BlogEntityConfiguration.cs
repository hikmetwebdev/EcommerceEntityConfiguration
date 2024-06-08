using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonEcommerce.Data.Persistances.Configurations
{
    public class BlogEntityConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(m=>m.Id).HasColumnType("int");
            builder.Property(m => m.Name).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(m => m.Description).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(m => m.ImageUrl).HasColumnType("nvarchar");
            builder.HasKey(m => m.Id);

            builder.ConfigureAsAudutible();

        }
    }
}
