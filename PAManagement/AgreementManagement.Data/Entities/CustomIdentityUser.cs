using System;
using AgreementManagement.Data.Infrastructure;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace AgreementManagement.Data.Entities
{
    public class CustomIdentityUser : IdentityUser<int>, IEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public ICollection<Agreement> Agreements { get; set; }
    }

    public class CustomIdentityUserLogin : IdentityUserLogin<int> { }

    public class CustomIdentityUserRole : IdentityUserRole<int> { }

    public class CustomIdentityUserClaim : IdentityUserClaim<int> { }

    public class CustomIdentityRole : IdentityRole<int> { }
}
