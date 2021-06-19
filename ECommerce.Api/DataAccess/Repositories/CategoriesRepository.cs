using AutoMapper;
using ECommerce.Api.DataAccess.Base;
using ECommerce.Api.DataAccess.Entities;
using ECommerce.Api.DataAccess.IRepositories;

namespace ECommerce.Api.DataAccess.Repositories
{
    public class CategoriesRepository : BaseRepository<Model.Category, Category>, ICategoriesRepository
    {
        public CategoriesRepository(IMapper mapper, ECommerceContext baseDbContext)
            : base(mapper, baseDbContext) {
        }
    }
}
