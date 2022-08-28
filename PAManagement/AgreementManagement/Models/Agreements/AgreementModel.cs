using System;

namespace AgreementManagement.Models
{
    public class AgreementModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string ProductGroupCode { get; set; }
        public string ProductGroupDescrption { get; set; }
        public string ProductNumber { get; set; }
        public string ProductDescrption { get; set; }
        public DateTime EffectiveDate  { get; set; }
        public DateTime ExpirationDate  { get; set; }
        public long ProductPrice  { get; set; }
        public long NewPrice  { get; set; }
    }
}
