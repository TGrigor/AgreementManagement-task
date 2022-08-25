using AgreementManagement.Data.Entities;
using AgreementManagement.Data.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AgreementManagement.Data
{
    public partial class AgreementManagementDbContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, int>
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<Agreement> Agreements { get; set; }

        public AgreementManagementDbContext(DbContextOptions<AgreementManagementDbContext> options)
            : base(options)
        {
        }

        private void SetTrackingProperties()
        {
            foreach (var entityAccessor in ChangeTracker.Entries())
            {
                if (entityAccessor.Entity is IEntity entity)
                {
                    entity.UpdatedOn = DateTime.UtcNow;
                    switch (entityAccessor.State)
                    {
                        case EntityState.Added:
                            entity.IsDeleted = false;
                            entity.CreatedOn = DateTime.UtcNow;
                            break;
                        case EntityState.Deleted:
                            entity.IsDeleted = true;
                            entityAccessor.State = EntityState.Modified;
                            break;
                    }
                }
            }
        }

        public override int SaveChanges()
        {
            SetTrackingProperties();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetTrackingProperties();
            return base.SaveChangesAsync(cancellationToken);
        }

        public int SaveChangesWithoutTracking()
            => base.SaveChanges();

        public Task<int> SaveChangesAsyncWithoutTracking(CancellationToken cancellationToken = default)
            => base.SaveChangesAsync(cancellationToken);
    }
}
