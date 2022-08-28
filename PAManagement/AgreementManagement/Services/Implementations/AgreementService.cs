using AgreementManagement.Data;
using AgreementManagement.Data.Entities;
using AgreementManagement.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<DataTableDataModel<List<AgreementModel>>> GetAgreementPaginatedData(DataTableDataModel<List<AgreementModel>> model)
        {
            //Paging Size (10,20,50,100)    
            int pageSize = model.Length != null ? Convert.ToInt32(model.Length) : 0;
            int skip = model.Start != null ? Convert.ToInt32(model.Start) : 0;

            // Getting all Agreement data 
            var queryResult = GetAll();
            var agreementsQuery = queryResult.ProjectTo<AgreementModel>(_mapper.ConfigurationProvider);

            //Sorting    
            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                //TODO: It will be better to use Enum for asc and desc
                if (model.SortColumnDir.ToString() == "desc")
                {
                    agreementsQuery = agreementsQuery.OrderByDescending(s => EF.Property<object>(s, model.SortColumn));
                }
                else
                {
                    agreementsQuery = agreementsQuery.OrderBy(s => EF.Property<object>(s, model.SortColumn));
                }
            }

            //Search    
            if (!string.IsNullOrEmpty(model.SearchValue))
            {
                agreementsQuery = agreementsQuery.Where(m => m.ProductNumber.Contains(model.SearchValue) || 
                                                             m.ProductGroupCode.Contains(model.SearchValue) ||
                                                             m.Username.Contains(model.SearchValue));
            }

            model.RecordsTotalCount = agreementsQuery.Count();

            //Paging     
            model.Data = await agreementsQuery.Skip(skip).Take(pageSize).ToListAsync();
            return model;
        }

        public async Task<T> GetAgreementAsync<T>(int id)
        {
            var result = GetAll().Where(s => s.Id == id);
            return await result.ProjectTo<T>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<bool> IsAgreementExist(int id)
             => await _context.Agreements.AnyAsync(s => s.Id == id);

        public async Task CreateAgreementAsync(int userId, AgreementCreateModel model)
        {
            var newAgreement = _mapper.Map<Agreement>(model);
            var selectedProduct = _context.Products.FirstOrDefault(s => s.Id == model.ProductId);
            newAgreement.UserId = userId;
            newAgreement.ProductPrice = selectedProduct.Price;
            await _context.Agreements.AddAsync(newAgreement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAgreementAsync(int userId, AgreementEditModel model)
        {
            var agreementEditModel = _mapper.Map<Agreement>(model);
            var selectedProduct = _context.Products.FirstOrDefault(s => s.Id == model.ProductId);
            agreementEditModel.UserId = userId;
            agreementEditModel.ProductPrice = selectedProduct.Price;
            _context.Update(agreementEditModel);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAgreementAsync(int agreementId)
        {
            var agreement = await _context.Agreements.FindAsync(agreementId);
            _context.Agreements.Remove(agreement);
            await _context.SaveChangesAsync();
        }

        private IQueryable<Agreement> GetAll()
           => _context.Agreements.Include(a => a.IdentityUser).Include(a => a.Product).Include(a => a.ProductGroup);
    }
}
