using AgreementManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgreementManagement.Data.Infrastructure.Configuration
{
    internal class AgreementConfiguration : IEntityTypeConfiguration<Agreement>
    {
        public void Configure(EntityTypeBuilder<Agreement> builder)
        {
            builder.ToTable("Agreement");

            #region Relationships
            builder.HasOne(s => s.IdentityUser)
                   .WithMany(s => s.Agreements)
                   .HasForeignKey(s => s.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.Product)
                   .WithMany(s => s.Agreements)
                   .HasForeignKey(s => s.ProductId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.ProductGroup)
                   .WithMany(m => m.Agreements)
                   .HasForeignKey(s => s.ProductGroupId)
                   .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
