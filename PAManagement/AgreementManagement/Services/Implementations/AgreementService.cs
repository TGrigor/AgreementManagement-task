﻿using AgreementManagement.Data;
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
