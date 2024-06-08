using Infrastructure.Commons.Concrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonEcommerce.Data.Persistances.Configurations
{
    public static class ConfigurationHelper
    {
        public static EntityTypeBuilder<T> ConfigureAsAudutible<T>(this EntityTypeBuilder<T> builder)
            where T : AuditibleEntity
        {
            builder.Property(m => m.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(m => m.CreatedAt).HasColumnType("datetime").IsRequired();

            builder.Property(m => m.ModifiedAt).HasColumnType("datetime");
            builder.Property(m => m.ModifiedBy).HasColumnType("int");

            builder.Property(m => m.DeletedAt).HasColumnType("datetime");
            builder.Property(m => m.DeletedBy).HasColumnType("int");

            return builder;
        }
    }
}
