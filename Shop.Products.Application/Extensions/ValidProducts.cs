

using Shop.Products.Application.Base;
using Shop.Products.Application.Dtos;

namespace Shop.Products.Application.Extensions
{
    public static class ValidProducts
    {
        public static ServiceResult IsValidProduct(this ProductsDtoSave productsDtoSave)
        {
            ServiceResult result = new ServiceResult();
            if (productsDtoSave is null)
            {
                result.Success = false;
                result.Message = $"El objeto {nameof(productsDtoSave)} es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(productsDtoSave.ProductName))
            {
                result.Success = false;
                result.Message = $"El nombre del producto es requerido.";
                return result;
            }
                // Add additional validation rules as needed for ProductsDtoSave

                return result;
            }

            public static ServiceResult IsValidProduct(this ProductsDtoUpdate productsDtoUpdate)
            {
                ServiceResult result = new ServiceResult();
                if (productsDtoUpdate is null)
                {
                    result.Success= false;
                    result.Message = $"El objeto {nameof(productsDtoUpdate)} es requerido.";
                    return result;
                }

                if (string.IsNullOrEmpty (productsDtoUpdate.ProductName))
                {
                    result.Success = false;
                result.Message = $"El nombre del producto es requerido.";
                }  
                return result;
        }
    }
}
