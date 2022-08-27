using AgreementManagement.Data.Entities;
using System.Collections.Generic;

namespace AgreementManagement.Data.Infrastructure.SeedData
{
    public static class SeedDataHelper
    {
        public static List<Product> GetTestProducts(bool isWithIdentity = true)
        {
            var product1 = new Product
            {
                Price = 100,
                ProductDescription = "Test 1 Description",
                ProductNumber = "#00001",
                CreatedOn = System.DateTime.Now,
                UpdatedOn = System.DateTime.Now,
                IsDeleted = false,
                ProductGroupId = 1,
            };
            var product2 = new Product
            {
                Price = 200,
                ProductDescription = "Test 2 Description",
                ProductNumber = "#00002",
                CreatedOn = System.DateTime.Now,
                UpdatedOn = System.DateTime.Now,
                IsDeleted = false,
                ProductGroupId = 1,
            };
            var product3 = new Product
            {
                Price = 300,
                ProductDescription = "Test 3 Description",
                ProductNumber = "#00003",
                CreatedOn = System.DateTime.Now,
                UpdatedOn = System.DateTime.Now,
                IsDeleted = false,
                ProductGroupId = 1,
            };
            var product4 = new Product
            {
                Price = 400,
                ProductDescription = "Test 4 Description",
                ProductNumber = "#00004",
                CreatedOn = System.DateTime.Now,
                UpdatedOn = System.DateTime.Now,
                IsDeleted = false,
                ProductGroupId = 2,
            };
            var product5 = new Product
            {
                Price = 500,
                ProductDescription = "Test 5 Description",
                ProductNumber = "#00005",
                CreatedOn = System.DateTime.Now,
                UpdatedOn = System.DateTime.Now,
                IsDeleted = false,
                ProductGroupId = 2,
            };

            if (isWithIdentity)
            {
                product1.Id = 1;
                product2.Id = 2;
                product3.Id = 3;
                product4.Id = 4;
                product5.Id = 5;
            }

            return new List<Product> {
                       product1,
                       product2,
                       product3,
                       product4,
                       product5
                    };
        }
        public static List<ProductGroup> GetTestProductGroups(bool isWithIdentity = true)
        {
            var prodGroup1 = new ProductGroup
            {
                GroupCode = "#001",
                GroupDescription = "Group 1",
                CreatedOn = System.DateTime.Now,
                UpdatedOn = System.DateTime.Now,
                IsDeleted = false,
            };
            var prodGroup2 = new ProductGroup
            {
                GroupCode = "#002",
                GroupDescription = "Group 2",
                CreatedOn = System.DateTime.Now,
                UpdatedOn = System.DateTime.Now,
                IsDeleted = false,
            };

            if (isWithIdentity)
            {
                prodGroup1.Id = 1;
                prodGroup2.Id = 2;
            }

            return new List<ProductGroup> {
                        prodGroup1,
                        prodGroup2
                    };
        }
        public static void SeedTestData(this AgreementManagementDbContext context)
        {
            context.ProductGroups.AddRange(GetTestProductGroups(false));
            context.Products.AddRange(GetTestProducts(false));
            context.SaveChangesAsync();
        }
    }
}
