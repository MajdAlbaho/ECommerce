using ECommerce.Api.DataAccess.Base;
using ECommerce.Api.DataAccess.Entities;
using ECommerce.Model.Base;

namespace ECommerce.Api.DataAccess.IRepositories
{
    public interface IProductsRepository : IBaseRepository<Model.Product, Product>, IInjectable
    {

    }
}
