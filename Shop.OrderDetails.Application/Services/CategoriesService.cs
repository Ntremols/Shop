
using Microsoft.Extensions.Logging;
using Shop.Categories.Application.Contracts;
using Shop.Categories.Application.Base;
using Shop.Categories.Application.Dtos;
using Shop.Categories.Domain.Interfaces;
using Shop.Categories.Application.Extensions;
using Shop.Categories.Domain.Entities;

namespace Shop.Categories.Application.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository categoriesRepository;
        private readonly ILogger<CategoriesService> logger;

        public CategoriesService(ICategoriesRepository categoriesRepository, ILogger<CategoriesService> logger)
        {
            this.categoriesRepository = categoriesRepository;
            this.logger = logger;
        }

        public ServiceResult GetCategories()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var categories = this.categoriesRepository.GetAll();

                result.Result = (from category in categoriesRepository.GetAll()
                                 where category.Deleted == false
                                 select new CategoriesDtoGetAll()
                                 {
                                     CategoryId = category.Id,
                                     CategoryName = category.CategoryName,
                                     Description = category.Description,
                                     CreationDate = category.CreationDate,
                                     CreationUser = category.CreationUser
                                 }).OrderByDescending(cd => cd.CreationDate).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las categorias.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }
            return result;
           
        }



        public ServiceResult GetCategoryById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Result = (from category in categoriesRepository.GetAll()
                                 where category.Id == id
                                 && category.Deleted == false

                                 select new CategoriesDtoGetAll()
                                 {
                                     CategoryId = category.Id,
                                     CategoryName = category.CategoryName,
                                     Description = category.Description,
                                     CreationDate = category.CreationDate,
                                     CreationUser = category.CreationUser
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

        public ServiceResult RemoveCategories(CategoriesDtoRemove categoryDtoRemove)
        {
            ServiceResult result = new ServiceResult();

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
                    Deleted = categoryDtoRemove.Deleted,
                    DeleteDate = categoryDtoRemove.DeleteDate,
                    DeleteUser = categoryDtoRemove.DeleteUser

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

        public ServiceResult SaveCategories(CategoriesDtoSave categoryDtoSave)
        {
           ServiceResult result = new ServiceResult();

            try
            {
                result = categoryDtoSave.IsValidCategory();

                if (!result.Success)
                    return result;

                Domain.Entities.Categories category = new Domain.Entities.Categories()
                {
                    CategoryName = categoryDtoSave.CategoryName,
                    Description = categoryDtoSave.Description,
                    CreationDate = categoryDtoSave.CreationDate,
                    CreationUser = categoryDtoSave.CreationUser,
                    Deleted = false
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



        public ServiceResult UpdateCategories(CategoriesDtoUpdate categoriesDtoUpdate)
        {

            ServiceResult result = new ServiceResult();

            try
            {

                result = categoriesDtoUpdate.IsValidCategory();

                if (!result.Success)
                    return result;


                Domain.Entities.Categories category = new Domain.Entities.Categories()
                {
                    Id = categoriesDtoUpdate.CategoryId,
                    CategoryName = categoriesDtoUpdate.CategoryName,
                    Description = categoriesDtoUpdate.Description,
                    ModifyDate = categoriesDtoUpdate.ModifyDate,
                    ModifyUser = categoriesDtoUpdate.ModifyUser
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
