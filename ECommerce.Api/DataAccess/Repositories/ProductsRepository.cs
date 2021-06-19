using System;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Api.DataAccess.Base;
using ECommerce.Api.DataAccess.Entities;
using ECommerce.Api.DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.DataAccess.Repositories
{
    public class ProductsRepository : BaseRepository<Model.Product, Product>, IProductsRepository
    {
        private readonly IMapper _mapper;
        private readonly ECommerceContext _context;

        public ProductsRepository(IMapper mapper, ECommerceContext context)
            : base(mapper, context) {
            _mapper = mapper;
            _context = context;
        }
    }
}
