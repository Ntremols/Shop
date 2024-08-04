
using Shop.Suppliers.Application.Base;
using Shop.Suppliers.Application.Dtos;


namespace Shop.Suppliers.Application.Contracts
{
    public interface ISuppliersServices
    {
        ServicesResult<List<SuppliersDtoGetAll>> GetSuppliers();
        ServicesResult<SuppliersDtoGetAll> GetSuppliersById(int id);
        ServicesResult<SuppliersDtoUpdate> UpdateSuppliers(SuppliersDtoUpdate suppliersDtoUpdate);
        ServicesResult<SuppliersDtoRemove> RemoveSuppliers(SuppliersDtoRemove suppliersDtoRemove);
        ServicesResult<SuppliersDtoSave> SaveSuppliers(SuppliersDtoSave suppliersDtoSave);

    }
}

