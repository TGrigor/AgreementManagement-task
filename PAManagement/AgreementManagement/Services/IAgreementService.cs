using AgreementManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgreementManagement.Services
{
    public interface IAgreementService
    {
        public Task<IEnumerable<AgreementModel>> GetAgreementListAsync();
        Task<AgreementModel> GetAgreementAsync(int id);
    }
}
