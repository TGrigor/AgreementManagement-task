using AgreementManagement.Data.Infrastructure;
using System.Collections.Generic;

namespace AgreementManagement.Data.Entities
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductNumber { get; set; }
        public long Price { get; set; }

        public ProductGroup ProductGroup { get; set; }
        public virtual ICollection<Agreement> Agreements { get; set; }
    }
}
