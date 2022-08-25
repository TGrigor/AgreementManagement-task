using AgreementManagement.Data.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AgreementManagement.Data
{
    public partial class AgreementManagementDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductGroupConfiguration());
            modelBuilder.ApplyConfiguration(new AgreementConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
