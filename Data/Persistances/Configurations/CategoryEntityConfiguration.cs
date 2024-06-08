using BigonEcommerce.Data.Persistances.Configurations;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonEcommerce.Models.Persistances.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int");
            builder.Property(m => m.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();

            builder.ConfigureAsAudutible();
            builder.HasKey(m => m.Id);

            builder.HasOne<Category>()
                .WithMany()
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasPrincipalKey(c => c.Id);
        }
    }
}
