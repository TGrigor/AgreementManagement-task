using AgreementManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgreementManagement.Data.Infrastructure.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            #region Relationships
            builder.HasOne(s => s.ProductGroup)
                   .WithMany(m => m.Products)
                   .HasForeignKey(s => s.ProductGroupId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.Agreements)
                   .WithOne(s => s.Product)
                   .HasForeignKey(s => s.ProductId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(s => s.ProductNumber).IsUnique();
            #endregion

            #region Seed Data
            builder.HasData(new Product
            {
                Id = 1,
                Price = 100,
                ProductDescription = "Test 1 Description",
                ProductNumber = "#00001",
                CreatedOn = System.DateTime.Now,
                UpdatedOn = System.DateTime.Now,
                IsDeleted = false,
                ProductGroupId = 1,
            });
            builder.HasData(new Product
            {
                Id = 2,
                Price = 200,
                ProductDescription = "Test 2 Description",
                ProductNumber = "#00002",
                CreatedOn = System.DateTime.Now,
                UpdatedOn = System.DateTime.Now,
                IsDeleted = false,
                ProductGroupId = 1,
            });
            builder.HasData(new Product
            {
                Id = 3,
                Price = 300,
                ProductDescription = "Test 3 Description",
                ProductNumber = "#00003",
                CreatedOn = System.DateTime.Now,
                UpdatedOn = System.DateTime.Now,
                IsDeleted = false,
                ProductGroupId = 1,
            });
            builder.HasData(new Product
            {
                Id = 4,
                Price = 400,
                ProductDescription = "Test 4 Description",
                ProductNumber = "#00004",
                CreatedOn = System.DateTime.Now,
                UpdatedOn = System.DateTime.Now,
                IsDeleted = false,
                ProductGroupId = 2,
            });
            builder.HasData(new Product
            {
                Id = 5,
                Price = 500,
                ProductDescription = "Test 5 Description",
                ProductNumber = "#00005",
                CreatedOn = System.DateTime.Now,
                UpdatedOn = System.DateTime.Now,
                IsDeleted = false,
                ProductGroupId = 2,
            });
            #endregion
        }
    }
}
