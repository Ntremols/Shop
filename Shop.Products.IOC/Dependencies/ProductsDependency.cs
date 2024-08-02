
using Microsoft.Extensions.DependencyInjection;
using Shop.Products.Application.Contracts;
using Shop.Products.Application.Services;
using Shop.Products.Domain.Interfaces;
using Shop.Products.Persistence.Repositories;

namespace Shop.Products.IOC.Dependencies
{
    public static class ProductsDependency
    {
            public static void AddProductsDependency(this IServiceCollection services)
            {
                #region"Repositories"
                services.AddScoped<IProductsRepository, ProductsRepository>();
                #endregion

                #region "Services"
                services.AddTransient<IproductsServices, productsServices>();
                #endregion
            }
    }
}
