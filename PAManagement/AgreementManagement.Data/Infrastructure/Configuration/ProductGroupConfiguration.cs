using AgreementManagement.Data.Entities;
using AgreementManagement.Data.Infrastructure.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgreementManagement.Data.Infrastructure.Configuration
{
    internal class ProductGroupConfiguration : IEntityTypeConfiguration<ProductGroup>
    {
        public void Configure(EntityTypeBuilder<ProductGroup> builder)
        {
            builder.ToTable("ProductGroup");

            #region Relationships
            builder.HasMany(s => s.Products)
                   .WithOne(m => m.ProductGroup)
                   .HasForeignKey(s => s.ProductGroupId)
                   .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasIndex(s => s.GroupCode).IsUnique();
            #endregion

            #region Seed Data
            builder.HasData(SeedDataHelper.GetTestProductGroups());
            #endregion
        }
    }
}
