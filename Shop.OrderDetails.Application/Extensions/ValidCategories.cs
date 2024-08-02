
using Shop.Categories.Application.Base;
using Shop.Categories.Application.Dtos;

namespace Shop.Categories.Application.Extensions
{
    public static class ValidCategories
    {
        public static ServicesResult IsValidCategory(this DtoBaseCategories baseCategory)
        {
            ServicesResult result = new ServicesResult();

            if (baseCategory is null)
            {
                result.Success = false;
                result.Message = $"El objeto {nameof(baseCategory)} es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(baseCategory.categoryname))
            {
                result.Success = false;
                result.Message = $"El nombre de la categoría es requerido.";
                return result;
            }

            if (baseCategory.categoryname.Length > 40)
            {
                result.Success = false;
                result.Message = $"El nombre de la categoria no puede ser mayor a 40 caracteres.";
                return result;
            } 

            if (string.IsNullOrEmpty(baseCategory.description))
            {
                result.Success = false;
                result.Message = $"La descripcion es requerida.";
                return result;
            }

            if (baseCategory.description.Length > 90)
            {
                result.Success = false;
                result.Message = $"La descripcion no puede ser mayor a 90 caracteres.";
                return result;
            }

            result.Success = true;
            result.Message = "Sus datos han sido validados con exito.";
            return result;

        }
    }
}

