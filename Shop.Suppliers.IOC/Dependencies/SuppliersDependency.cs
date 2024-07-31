

using Microsoft.Extensions.DependencyInjection;
using Shop.Suppliers.Application.Services;
using Shop.Suppliers.Domain.Interfaces;
using Shop.Suppliers.Persistence.Repositories;
using Shop.Suppliers.Application.Contracts;

namespace Shop.Suppliers.IOC.Dependencies
{
    public static class SuppliersDependency
    {
        public static void AddSuppliersDependency(this IServiceCollection service)
        {
            #region"Repository"
            service.AddScoped<ISuppliersRepository, SuppliersRepository>();
            #endregion

            #region"Services"
            service.AddTransient<ISuppliersServices, SuppliersServices>();
            #endregion


        }
    }
}
