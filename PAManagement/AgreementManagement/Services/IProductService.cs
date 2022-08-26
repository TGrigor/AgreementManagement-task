using AgreementManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgreementManagement.Services
{
    public interface IProductService
    {
        Task<IEnumerable<KeyValueModel<string>>> GetProductsSimpleData();
        Task<IEnumerable<KeyValueModel<string>>> GetProductGroupsSimpleData();
    }
}
