
using Shop.Categories.Application.Base;
using Shop.Categories.Application.Dtos;

namespace Shop.Categories.Application.Contracts
{
    public interface ICategoriesService
    {
        ServiceResult GetCategories();
        ServiceResult GetCategoryById(int id);
        ServiceResult UpdateCategories(CategoriesDtoUpdate categoriesDtoUpdate);
        ServiceResult RemoveCategories(CategoriesDtoRemove categoriesDtoRemove);
        ServiceResult SaveCategories(CategoriesDtoSave categoriesDtoSave);
    }
}
