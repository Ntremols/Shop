using Shop.Products.Application.Base;
using Shop.Products.Application.Dtos;

namespace Shop.Products.Application.Contracts
{
    public interface IProductsService
    {
        ServiceResult GetProducts();
        ServiceResult GetProductsById(int id);
        ServiceResult UpdateProducts(ProductsDtoUpdate productsDtoUpdate);
        ServiceResult RemoveProducts(ProductsDtoRemove productsDtoRemove);
        ServiceResult SaveProducts(ProductsDtoSave productsDtoSave);
    }
}
