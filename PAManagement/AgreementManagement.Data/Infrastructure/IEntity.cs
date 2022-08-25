using System;

namespace AgreementManagement.Data.Infrastructure
{
    public interface IEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
