

using Shop.Products.Application.Base;
using Shop.Products.Application.Dtos;


namespace Shop.Products.Application.Extensions
{
    public static class ValidProducts
    {
        public static ServicesResult IsValidProduct(this DtoBaseProducts baseProducts)
        {
            ServicesResult result = new ServicesResult();

            if (baseProducts is null)
            {
                result.Success = false;
                result.Message = $"El objeto {nameof(baseProducts)} es requerido.";
                return result;
            }
           
            if (string.IsNullOrEmpty(baseProducts.productname))
            {
                result.Success= false;
                result.Message = $"El nombre del producto es requerido.";
                return result;
            }

            if (baseProducts.productname.Length > 50)
            {
                result.Success = false;
                result.Message = $"El nombre del producto no puede ser mayor a 50 caracteres.";
                return result;
            }  


            result.Success = true;
            result.Message = "Sus resultados han sido validados con exito.";
            return result;
        }
    }
}
