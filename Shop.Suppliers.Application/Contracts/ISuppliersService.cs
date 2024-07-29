
using Shop.Suppliers.Application.Base;
using Shop.Suppliers.Application.Dtos;

namespace Shop.Suppliers.Application.Contracts
{
    public interface ISuppliersService
    {
        ServiceResult GetSuppliers();
        ServiceResult GetSuppliersById(int id);
        ServiceResult UpdateSuppliers(SuppliersDtoUpdate suppliersDtoUpdate);
        ServiceResult RemoveSuppliers(SuppliersDtoRemove suppliersDtoRemove);
        ServiceResult SaveSuppliers(SuppliersDtoSave suppliersDtoSave);
    }
}
