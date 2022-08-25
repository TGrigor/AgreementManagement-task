using AgreementManagement.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AgreementManagement.Data
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AgreementManagementDbContext>(optionBuilder => {
                optionBuilder.UseSqlServer(
                    connectionString ?? throw new ArgumentException("Connection string is not passed"),
                    o => o.EnableRetryOnFailure(3));
            });
            services.AddRepositories();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddDefaultIdentity<CustomIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AgreementManagementDbContext>();
            return services;
        }

        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AgreementManagementDbContext>();
            context?.Database.Migrate();
            return app;
        }
    }
}
