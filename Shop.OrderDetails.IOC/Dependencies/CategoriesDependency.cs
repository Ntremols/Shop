
using Microsoft.Extensions.DependencyInjection;
using Shop.Categories.Application.Contracts;
using Shop.Categories.Application.Services;
using Shop.Categories.Domain.Interfaces;
using Shop.Categories.Persistence.Repositories;

namespace Shop.Categories.IOC.Dependencies
{
    public static class CategoriesDependency
    {
        public static void AddCategoriesDependency(this IServiceCollection service)
        {
            #region"Repositories"
            service.AddScoped<ICategoriesRepository, CategoriesRepository>();
            #endregion

            #region "Services"
            service.AddTransient<ICategoriesService, CategoriesService>();
            #endregion
        }
    }
}
