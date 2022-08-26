using System;
using AgreementManagement.Data.Infrastructure;

namespace AgreementManagement.Data.Entities
{
    public class Agreement : BaseEntity
    {
        public int UserId  { get; set; }
        public int ProductId { get; set; }
        public int ProductGroupId  { get; set; }
        public DateTime EffectiveDate  { get; set; }
        public DateTime ExpirationDate  { get; set; }
        public long ProductPrice  { get; set; }
        public long NewPrice  { get; set; }
        public bool Active { get; set; } = true;

        public virtual CustomIdentityUser IdentityUser { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
    }
}
