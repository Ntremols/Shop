using Shop.WebApp.Models;
using Shop.WebApp.Models.Suppliers;
using Shop.WebApp.Models.Suppliers.Result;

namespace Shop.WebApp.Interfaces
{
    public interface ISuppliersServices
    {
        Task<SuppliersListGetResult> GetSuppliers();
        Task<SuppliersGetResult> GetSuppliersById (int id);
        Task<SuppliersSaveResult> SuppliersSave(SuppliersSaveModel suppliersSaveModel);
        Task<SuppliersUpdateResult> SuppliersUpdate(SuppliersUpdateModel suppliersUpdateModel);
    }
}
