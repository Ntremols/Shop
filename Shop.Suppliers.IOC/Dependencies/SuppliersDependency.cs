

using Microsoft.Extensions.DependencyInjection;
using Shop.Suppliers.Application.Services;
using Shop.Suppliers.Domain.Interfaces;
using Shop.Suppliers.Persistence.Repositories;
using Shop.Suppliers.Application.Contracts;

namespace Shop.Suppliers.IOC.Dependencies
{
    public static class SuppliersDependency
    {
        public static void AddSuppliersDependency(this IServiceCollection services)
        {
            #region"Repository"
            services.AddScoped<ISuppliersRepository, SuppliersRepository>();
            #endregion

            #region"Services"
            services.AddTransient<ISuppliersServices, SuppliersServices>();
            #endregion


        }
    }
}
