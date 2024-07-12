
using Shop.Products.Domain.Entities;
using Shop.Common.Data.Repository;

namespace Shop.Products.Domain.Interfaces
{
    public interface IProductsRepository : IBaseRepository<Domain.Entities.Products,int>
    {
        List<Products.Domain.Entities.Products> GetProductsByDeparmentId(int deparmentId);
    }
}
