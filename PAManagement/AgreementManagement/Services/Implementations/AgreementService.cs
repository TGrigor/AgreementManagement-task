using AgreementManagement.Data;
using AgreementManagement.Data.Entities;
using AgreementManagement.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgreementManagement.Services.Implementations
{
    internal class AgreementService : IAgreementService
    {
        private AgreementManagementDbContext _context;
        private IMapper _mapper;

        public AgreementService(AgreementManagementDbContext context,
                                IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AgreementModel>> GetAgreementListAsync()
        {
            var result = GetAll();
            return await result.ProjectTo<AgreementModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<AgreementModel> GetAgreementAsync(int id)
        {
            var result = GetAll().Where(s => s.Id == id);
            return await result.ProjectTo<AgreementModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        private IQueryable<Agreement> GetAll()
           => _context.Agreements.Include(a => a.IdentityUser).Include(a => a.Product).Include(a => a.ProductGroup);

    }
}
