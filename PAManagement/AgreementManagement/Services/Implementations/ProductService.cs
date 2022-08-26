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
    internal class ProductService : IProductService
    {
        private AgreementManagementDbContext _context;
        private IMapper _mapper;

        public ProductService(AgreementManagementDbContext context,
                                IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<KeyValueModel<string>>> GetProductsSimpleData()
             //TODO-Improve:We can create extension method for IQueryable to filter IsDeleted
             => await _context.Products.Where(s => !s.IsDeleted).ProjectTo<KeyValueModel<string>>(_mapper.ConfigurationProvider).ToListAsync();

        public async Task<IEnumerable<KeyValueModel<string>>> GetProductGroupsSimpleData()
             //TODO-Improve:We can create extension method for IQueryable to filter IsDeleted
             => await _context.ProductGroups.Where(s => !s.IsDeleted).ProjectTo<KeyValueModel<string>>(_mapper.ConfigurationProvider).ToListAsync();
    }
}
