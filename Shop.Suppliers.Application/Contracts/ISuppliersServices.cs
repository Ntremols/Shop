
using Shop.Suppliers.Application.Base;
using Shop.Suppliers.Application.Dtos;

namespace Shop.Suppliers.Application.Contracts
{
    public interface ISuppliersServices
    {
        ServicesResult GetSuppliers();
        ServicesResult GetSuppliersById(int id);
        ServicesResult UpdateSuppliers(SuppliersDtoUpdate suppliersDtoUpdate);
        ServicesResult RemoveSuppliers(SuppliersDtoRemove suppliersDtoRemove);
        ServicesResult SaveSuppliers(SuppliersDtoSave suppliersDtoSave);
    }
}
