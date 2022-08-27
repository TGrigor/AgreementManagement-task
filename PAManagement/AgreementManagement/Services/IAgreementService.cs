using AgreementManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgreementManagement.Services
{
    public interface IAgreementService
    {
        Task<IEnumerable<AgreementModel>> GetAgreementListAsync();
        Task<T> GetAgreementAsync<T>(int id);
        Task CreateAgreementAsync(int userId, AgreementCreateModel model);
        Task UpdateAgreementAsync(int userId, AgreementEditModel model);
        Task<bool> IsAgreementExist(int id);
        Task RemoveAgreementAsync(int agreementId);
    }
}
