using AgreementManagement.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using AgreementManagement.Data.Infrastructure.SeedData;

namespace AgreementManagement.Data
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, string connectionString)
        {
            bool isInMemory = string.IsNullOrEmpty(connectionString);
            services.AddDbContext<AgreementManagementDbContext>(optionBuilder => {
                if (isInMemory)
                {
                    optionBuilder.UseInMemoryDatabase("AgreementManagementDB-InMemory");
                }
                else
                {
                    optionBuilder.UseSqlServer(
                        connectionString ?? throw new ArgumentException("Connection string is not passed"),
                        o => o.EnableRetryOnFailure(3));
                }
            });
            services.AddRepositories();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddDefaultIdentity<CustomIdentityUser>()
                    .AddEntityFrameworkStores<AgreementManagementDbContext>();
            return services;
        }

        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AgreementManagementDbContext>();
            if (context.Database.IsSqlServer())
            {
                context?.Database.Migrate();
            }
            else
            {
                context.SeedTestData();
            }
            return app;
        }
    }
}
