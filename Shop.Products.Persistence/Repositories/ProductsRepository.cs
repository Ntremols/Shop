using Microsoft.Extensions.Logging;
using Shop.Products.Domain.Interfaces;
using Shop.Products.Persistence.Context;
using Shop.Products.Persistence.Exceptions;
using System.Linq.Expressions;

namespace Shop.Products.Persistence.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ShopContext _shopContext;
        private readonly ILogger<ProductsRepository> _logger;
        public ProductsRepository(ShopContext context, ILogger<ProductsRepository> logger)
        {
            _shopContext = context;
            _logger = logger;
        }
        public bool Exists(Expression<Func<Domain.Entities.Products, bool>> filter)
        {
           return this._shopContext.Products.Any(filter);
        }

        public List<Domain.Entities.Products> GetAll()
        {
            return this._shopContext.Products.ToList();
        }

        public Domain.Entities.Products GetEntityBy(int Id)
        {
            Domain.Entities.Products? products = null;
            try
            {
                products = this._shopContext.Products.Find(Id);

                if (products is null)
                    throw new ProductsException("El producto no se ha encontrado.");
                return products;
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error para encontrar el producto.", ex.ToString());
            }
            return products;
        }

        public List<Domain.Entities.Products> GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Products> GetProductsById(int productId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entities.Products entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException("La entidad del producto no puede ser null.");

                Domain.Entities.Products? productsToRemove = this._shopContext.Products.Find(entity.Id);

                productsToRemove.delete_user = entity.delete_user;
                productsToRemove.deleted = entity.deleted;
                productsToRemove.delete_date = entity.delete_date;

                _shopContext.Products.Update(productsToRemove);
                this._shopContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error eliminando el producto");
            }
        }

        public void Save(Domain.Entities.Products entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException("La entidad del producto no puede ser nulo.");

                if (Exists(co => co.productname.Equals(entity.productname)))
                    throw new ProductsException("El producto no se encuentra registrado.");

                _shopContext.Products.Add(entity);
                _shopContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error agregando el producto", ex.ToString());
            }
        }

        public void Update(Domain.Entities.Products entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException("La entidad de productos no puede ser nulo.");

                Domain.Entities.Products? productsToUpdate = this._shopContext.Products.Find(entity.Id);

                if (productsToUpdate == null)
                    throw new ProductsException("El producto que desea actualizar no se encuentra registrada.");

                productsToUpdate.modify_date = entity.modify_date;

                _shopContext.Products.Update(productsToUpdate);
                _shopContext.SaveChanges();

            }
            catch (Exception ex)
            {
                this._logger.LogError("Error actualizando el producto.", ex.ToString());
            }
        }
    }
}
