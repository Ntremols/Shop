
using Shop.Suppliers.Application.Base;
using Shop.Suppliers.Application.Dtos;

namespace Shop.Suppliers.Application.Extensions
{
    public static class ValidSuppliers
    {
        public static ServiceResult IsValidSupplier(this SuppliersDtoSave supplierDtoSave)
        {
            ServiceResult result = new ServiceResult();

            if (supplierDtoSave is null)
            {
                result.Success = false;
                result.Message = $"El objeto {nameof(supplierDtoSave)} es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(supplierDtoSave.CompanyName))
            {
                result.Success = false;
                result.Message = $"El nombre es requerido.";
                return result;
            }

            // Add additional validation rules as needed for SuppliersDtoSave

            return result;
        }

        public static ServiceResult IsValidSupplier(this SuppliersDtoUpdate supplierDtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            if (supplierDtoUpdate is null)
            {
                result.Success = false;
                result.Message = $"El objeto {nameof(supplierDtoUpdate)} es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(supplierDtoUpdate.CompanyName))
            {
                result.Success = false;
                result.Message = $"El nombre es requerido.";
                return result;
            }



            return result;
        }
    }
}
