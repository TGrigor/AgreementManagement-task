using AgreementManagement.Data.Entities;
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
            #endregion

            #region Seed Data
            builder.HasData(new ProductGroup
            {
                Id = 1,
                GroupCode = "#001",
                GroupDescription = "Group 1",
                CreatedOn = System.DateTime.Now,
                UpdatedOn = System.DateTime.Now,
                IsDeleted = false,
            });
            builder.HasData(new ProductGroup
            {
                Id = 2,
                GroupCode = "#002",
                GroupDescription = "Group 2",
                CreatedOn = System.DateTime.Now,
                UpdatedOn = System.DateTime.Now,
                IsDeleted = false,
            });
            #endregion
        }
    }
}
