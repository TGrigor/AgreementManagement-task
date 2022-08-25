using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgreementManagement.Data
{
    public class AgreementManagementDbContext : IdentityDbContext
    {
        public AgreementManagementDbContext(DbContextOptions<AgreementManagementDbContext> options)
            : base(options)
        {
        }
    }
}
