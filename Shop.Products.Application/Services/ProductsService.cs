using Microsoft.Extensions.Logging;
using Shop.Products.Application.Base;
using Shop.Products.Application.Contracts;
using Shop.Products.Application.Dtos;
using Shop.Products.Application.Extensions;
using Shop.Products.Domain.Interfaces;

namespace Shop.Products.Application.Services
{
    public class productsServices : IproductsServices
    {
        private readonly IProductsRepository productsRepository;
        private readonly ILogger<productsServices> logger;

        public productsServices(IProductsRepository productsRepository, ILogger<productsServices> logger)
        {
            this.productsRepository = productsRepository;
            this.logger = logger;
        }

        public ServicesResult GetProducts()
        {
            ServicesResult result = new ServicesResult();
            try
            {
                var products = this.productsRepository.GetAll();

                result.Result = (from product in productsRepository.GetAll()
                                 where product.deleted == false
                                 select new ProductsDtoGetAll()
                                 {
                                    productid = product.Id,
                                     productname = product.productname,
                                     unitprice = product.unitprice,
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


        public ServicesResult GetProductById(int id)
        {
            ServicesResult result = new ServicesResult();

            try
            {
                result.Result = (from product in productsRepository.GetAll()
                                 where product.Id == id
                                 && product.deleted == false

                                 select new ProductsDtoGetAll()
                                 {
                                     productid = product.Id,
                                     productname = product.productname,
                                     unitprice = product.unitprice,
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


        public ServicesResult RemoveProducts(ProductsDtoRemove productsDtoRemove)
        {
            ServicesResult result = new ServicesResult();

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
                    delete_date = productsDtoRemove.delete_date,
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

        public ServicesResult SaveProducts(ProductsDtoSave productsDtoSave)
        {
            ServicesResult result = new ServicesResult();

            try
            {
                result = productsDtoSave.IsValidProduct();

                if (!result.Success)
                    return result;

                Domain.Entities.Products products = new Domain.Entities.Products()
                {
                    productname = productsDtoSave.productname,
                    unitprice = productsDtoSave.unitprice,
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


        public ServicesResult UpdateProducts(ProductsDtoUpdate productsDtoUpdate)
        {

            ServicesResult result = new ServicesResult();

            try
            {

                result = productsDtoUpdate.IsValidProduct();

                if (!result.Success)
                    return result;


                Domain.Entities.Products products = new Domain.Entities.Products()
                {
                    Id = productsDtoUpdate.productid,
                    productname = productsDtoUpdate.productname,
                    unitprice = productsDtoUpdate.unitprice,
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

        public ServicesResult GetProductsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
