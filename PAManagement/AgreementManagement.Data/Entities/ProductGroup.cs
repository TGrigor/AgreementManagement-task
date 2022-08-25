using AgreementManagement.Data.Infrastructure;
using System.Collections.Generic;

namespace AgreementManagement.Data.Entities
{
    public class ProductGroup : BaseEntity
    {
        public int Id { get; set; }
        public string GroupDescription { get; set; }
        public string GroupCode  { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Agreement> Agreements { get; set; }
    }
}
