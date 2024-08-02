using Shop.Products.Application.Base;
using Shop.Products.Application.Dtos;

namespace Shop.Products.Application.Contracts
{
    public interface IproductsServices
    {
        ServicesResult GetProducts();
        ServicesResult GetProductsById(int id);
        ServicesResult UpdateProducts(ProductsDtoUpdate productsDtoUpdate);
        ServicesResult RemoveProducts(ProductsDtoRemove productsDtoRemove);
        ServicesResult SaveProducts(ProductsDtoSave productsDtoSave);
    }
}
