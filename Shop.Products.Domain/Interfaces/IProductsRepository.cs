

using Shop.Common.Data.Repository;

namespace Shop.Products.Domain.Interfaces
{
    public interface IProductsRepository : IBaseRepository<Entities.Products,int>
    {
        List<Entities.Products> GetProductsById(int productId);
    }
}
