using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonEcommerce.Data.Persistances.Configurations
{
    public class SubscriberEntityConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.Property(m=>m.EMailAdress).HasColumnType("varchar").HasMaxLength(160).IsRequired();
            builder.Property(m => m.IsApproved).HasColumnType("bit");
            builder.Property(m => m.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(m => m.ApprovedAt).HasColumnType("datetime");




            builder.HasKey(m=>m.EMailAdress);
        }
    }
}
