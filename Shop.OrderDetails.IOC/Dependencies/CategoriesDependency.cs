
using Microsoft.Extensions.DependencyInjection;
using Shop.Categories.Application.Contracts;
using Shop.Categories.Application.Services;
using Shop.Categories.Domain.Interfaces;
using Shop.Categories.Persistence.Repositories;

namespace Shop.Categories.IOC.Dependencies
{
    public static class CategoriesDependency
    {
        public static void AddCategoriesDependency(this IServiceCollection services)
        {
            #region"Repositories"
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            #endregion

            #region "Services"
            services.AddTransient<ICategoriesServices, CategoriesServices>();
            #endregion
        }
    }
}
