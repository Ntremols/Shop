using Microsoft.Extensions.Logging;
using Shop.Products.Application.Base;
using Shop.Products.Application.Contracts;
using Shop.Products.Application.Dtos;
using Shop.Products.Application.Extensions;
using Shop.Products.Domain.Interfaces;

namespace Shop.Products.Application.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository productsRepository;
        private readonly ILogger<ProductsService> logger;

        public ProductsService(IProductsRepository productsRepository, ILogger<ProductsService> logger)
        {
            this.productsRepository = productsRepository;
            this.logger = logger;
        }

        public ServiceResult GetProducts()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var products = this.productsRepository.GetAll();

                result.Result = (from product in productsRepository.GetAll()
                                 where product.deleted == false
                                 select new ProductsDtoGetAll()
                                 {
                                    ProductId = product.Id,
                                     ProductName = product.ProductName,
                                     UnitPrice = product.UnitPrice,
                                     creation_date = product.creation_date,
                                     creation_user = product.creation_user
                                 }).OrderByDescending(cd => cd.creation_date).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los productos.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }
            return result;

        }


        public ServiceResult GetProductById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Result = (from product in productsRepository.GetAll()
                                 where product.Id == id
                                 && product.deleted == false

                                 select new ProductsDtoGetAll()
                                 {
                                     ProductId = product.Id,
                                     ProductName = product.ProductName,
                                     UnitPrice = product.UnitPrice,
                                     creation_date = product.creation_date,
                                     creation_user = product.creation_user
                                 }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el producto.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }
            return result;
        }


        public ServiceResult RemoveProducts(ProductsDtoRemove productsDtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (productsDtoRemove is null)
                {
                    result.Success = false;
                    result.Message = $"El objeto{nameof(productsDtoRemove)} es requerido.";
                    return result;
                }

                Domain.Entities.Products product = new Domain.Entities.Products()
                {
                    Id = productsDtoRemove.Id,
                    deleted = productsDtoRemove.deleted,
                    delete_date = productsDtoRemove.DeleteTime,
                    delete_user = productsDtoRemove.delete_user

                };
                this.productsRepository.Remove(product);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error moviendo el producto.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult SaveProducts(ProductsDtoSave productsDtoSave)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = productsDtoSave.IsValidProduct();

                if (!result.Success)
                    return result;

                Domain.Entities.Products products = new Domain.Entities.Products()
                {
                    ProductName = productsDtoSave.ProductName,
                    UnitPrice = productsDtoSave.UnitPrice,
                    creation_date = productsDtoSave.creation_date,
                    creation_user = productsDtoSave.creation_user,
                    deleted = false
                };

                this.productsRepository.Save(products);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el producto.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }

            return result;
        }


        public ServiceResult UpdateProducts(ProductsDtoUpdate productsDtoUpdate)
        {

            ServiceResult result = new ServiceResult();

            try
            {

                result = productsDtoUpdate.IsValidProduct();

                if (!result.Success)
                    return result;


                Domain.Entities.Products products = new Domain.Entities.Products()
                {
                    Id = productsDtoUpdate.ProductId,
                    ProductName = productsDtoUpdate.ProductName,
                    UnitPrice = productsDtoUpdate.UnitPrice,
                    modify_date = productsDtoUpdate.modify_date,
                    modify_user = productsDtoUpdate.modify_user
                };

                this.productsRepository.Update(products);

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error actualizando el producto.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }


            return result;

        }

        public ServiceResult GetProductsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
