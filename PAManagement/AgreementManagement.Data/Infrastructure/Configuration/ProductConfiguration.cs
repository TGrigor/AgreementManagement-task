﻿using AgreementManagement.Data.Entities;
using AgreementManagement.Data.Infrastructure.SeedData;
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
            builder.HasData(SeedDataHelper.GetTestProducts());
            #endregion
        }
    }
}
