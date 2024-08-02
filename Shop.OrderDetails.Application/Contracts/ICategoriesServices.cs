
using Shop.Categories.Application.Base;
using Shop.Categories.Application.Dtos;

namespace Shop.Categories.Application.Contracts
{
    public interface ICategoriesServices
    {
        ServicesResult GetCategories();
        ServicesResult GetCategoryById(int id);
        ServicesResult UpdateCategories(CategoriesDtoUpdate categoriesDtoUpdate);
        ServicesResult RemoveCategories(CategoriesDtoRemove categoriesDtoRemove);
        ServicesResult SaveCategories(CategoriesDtoSave categoriesDtoSave);
    }
}
