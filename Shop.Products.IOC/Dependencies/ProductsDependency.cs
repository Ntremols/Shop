
using Microsoft.Extensions.DependencyInjection;
using Shop.Products.Application.Contracts;
using Shop.Products.Application.Services;
using Shop.Products.Domain.Interfaces;
using Shop.Products.Persistence.Repositories;

namespace Shop.Products.IOC.Dependencies
{
    public static class ProductsDependency
    {
            public static void AddProductsDependency(this IServiceCollection service)
            {
                #region"Repositories"
                service.AddScoped<IProductsRepository, ProductsRepository>();
                #endregion

                #region "Services"
                service.AddTransient<IProductsService, ProductsService>();
                #endregion
            }
    }
}
