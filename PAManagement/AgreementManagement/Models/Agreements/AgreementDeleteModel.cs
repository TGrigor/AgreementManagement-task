using System;

namespace AgreementManagement.Models
{
    public class AgreementDeleteModel
    {
        public int Id { get; set; }
        public int ProductGroupId { get; set; }
        public int ProductId { get; set; }
        public DateTime EffectiveDate  { get; set; }
        public DateTime ExpirationDate  { get; set; }
        public long NewPrice  { get; set; }
    }
}
