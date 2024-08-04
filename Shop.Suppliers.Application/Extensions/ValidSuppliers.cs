
using Shop.Suppliers.Application.Base;
using Shop.Suppliers.Application.Dtos;

namespace Shop.Suppliers.Application.Extensions
{
    public static class ValidSuppliers
    {
        public static ServicesResult<DtoBaseSuppliers> IsValidSupplier(this DtoBaseSuppliers baseSuppliers)
        {
            ServicesResult<DtoBaseSuppliers> result = new ServicesResult<DtoBaseSuppliers>();

            if ( baseSuppliers is null)
            {
                result.Success = false;
                result.Message = $"El objeto {nameof(baseSuppliers)} no puede ser null.";
                return result;
            }

            if (string.IsNullOrEmpty(baseSuppliers.companyname))
            {
                result.Success = false;
                result.Message = $"El nombre de la compania es requerido.";
                return result;
            }

            if (baseSuppliers.companyname.Length > 45)
            {
                result.Success = false;
                result.Message = "El nombre de la compania no puede ser mayor al 45";
                return result;
            }

            if (string.IsNullOrEmpty(baseSuppliers.contactname))
            {
                result.Success = false;
                result.Message = "El nombre del contacto es requerido";
                return result;
            }
            result.Success = true;
            result.Message = "Sus resultados han sido validados con exito.";
            return result;
        }
    }
}
