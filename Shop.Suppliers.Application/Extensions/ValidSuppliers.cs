
using Shop.Suppliers.Application.Base;
using Shop.Suppliers.Application.Dtos;

namespace Shop.Suppliers.Application.Extensions
{
    public static class ValidSuppliers
    {
        public static ServicesResult IsValidSupplier(this DtoBaseSuppliers baseSuppliers)
        {
            ServicesResult result = new ServicesResult();

            if ( baseSuppliers is null)
            {
                result.Success = false;
                result.Message = $"El objeto {nameof(baseSuppliers)} no puede ser null.";
                return result;
            }

            if (baseSuppliers.companyname is null)
            {
                result.Success = false;
                result.Message = $"El nombre es requerido.";
                return result;
            }

            if (baseSuppliers.companyname.Length > 45)
            {
                result.Success = false;
                result.Message = "El nombre de la compania no puede ser mayor al 40";
                return result;
            }

            if (baseSuppliers.contactname is null)
            {
                result.Success = false;
                result.Message = "El nombre del contacto es requerido";
                return result;
            }
            return result;
        }
    }
}
