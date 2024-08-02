
using Microsoft.Extensions.Logging;
using Shop.Categories.Application.Contracts;
using Shop.Categories.Application.Base;
using Shop.Categories.Application.Dtos;
using Shop.Categories.Domain.Interfaces;
using Shop.Categories.Application.Extensions;
using Shop.Categories.Domain.Entities;

namespace Shop.Categories.Application.Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly ICategoriesRepository categoriesRepository;
        private readonly ILogger<CategoriesServices> logger;

        public CategoriesServices(ICategoriesRepository categoriesRepository, ILogger<CategoriesServices> logger)
        {
            this.categoriesRepository = categoriesRepository;
            this.logger = logger;
        }

        public ServicesResult GetCategories()
        {
            ServicesResult result = new ServicesResult();
            try
            {
                var categories = this.categoriesRepository.GetAll();

                result.Result = (from category in categoriesRepository.GetAll()
                                 where category.deleted == false
                                 select new CategoriesDtoGetAll()
                                 {
                                     categoryid = category.Id,
                                     categoryname = category.categoryname,
                                     description = category.description,
                                     creation_date = category.creation_date,
                                     creation_user = category.creation_user
                                 }).OrderByDescending(cd => cd.creation_date).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las categorias.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }
            return result;
           
        }

        public ServicesResult GetCategoryById(int id)
        {
            ServicesResult result = new ServicesResult();

            try
            {
                result.Result = (from category in categoriesRepository.GetAll()
                                 where category.Id == id
                                 && category.deleted == false

                                 select new CategoriesDtoGetAll()
                                 {
                                     categoryid = category.Id,
                                     categoryname = category.categoryname,
                                     description = category.description,
                                     creation_date = category.creation_date,
                                     creation_user = category.creation_user
                                 }).FirstOrDefault();
            }
            catch(Exception ex)
            {
                result.Success=false;
                result.Message = "Error obteniendo la categoria.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }
            return result;
            }

        public ServicesResult RemoveCategories(CategoriesDtoRemove categoryDtoRemove)
        {
            ServicesResult result = new ServicesResult();

            try
            {
                if (categoryDtoRemove is null)
                {
                    result.Success = false;
                    result.Message = $"El objeto{nameof(categoryDtoRemove)} es requerido.";
                    return result;
                }

                Domain.Entities.Categories  category = new Domain.Entities.Categories()
                {
                    Id = categoryDtoRemove.Id,
                    deleted = categoryDtoRemove.deleted,
                    delete_date = categoryDtoRemove.delete_date,
                    delete_user = categoryDtoRemove.delete_user

                };
                this.categoriesRepository.Remove(category);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error moviendo la categoria.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }

            return result;
        }

        public ServicesResult SaveCategories(CategoriesDtoSave categoryDtoSave)
        {
           ServicesResult result = new ServicesResult();

            try
            {
                result = categoryDtoSave.IsValidCategory();

                if (!result.Success)
                    return result;

                Domain.Entities.Categories category = new Domain.Entities.Categories()
                {
                    categoryname = categoryDtoSave.categoryname,
                    description = categoryDtoSave.description,
                    creation_date = categoryDtoSave.creation_date,
                    creation_user = categoryDtoSave.creation_user,
                    deleted = false
                };

                this.categoriesRepository.Save(category);
            }
            catch (Exception ex)
            {
                result.Success= false;
                result.Message = "Error guardando la categoria.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }

            return result;
        }



        public ServicesResult UpdateCategories(CategoriesDtoUpdate categoriesDtoUpdate)
        {

            ServicesResult result = new ServicesResult();

            try
            {

                result = categoriesDtoUpdate.IsValidCategory();

                if (!result.Success)
                    return result;


                Domain.Entities.Categories category = new Domain.Entities.Categories()
                {
                    Id = categoriesDtoUpdate.categoryid,
                    categoryname = categoriesDtoUpdate.categoryname,
                    description = categoriesDtoUpdate.description,
                    modify_date = categoriesDtoUpdate.modify_date,
                    modify_user = categoriesDtoUpdate.modify_user
                };

                this.categoriesRepository.Update(category);

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error actualizando la categoria.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }
            return result;
            
        }
    }
}
