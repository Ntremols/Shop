using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Shop.Categories.Domain.Entities;
using Shop.Categories.Domain.Interfaces;
using Shop.Categories.Persistence.Context;
using Shop.Categories.Persistence.Exceptions;

namespace Shop.Categories.Persistence.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ShopContext _shopContext;

        private readonly ILogger<CategoriesRepository> _logger;
        public CategoriesRepository(ShopContext context, ILogger<CategoriesRepository> logger)
        {
            _shopContext = context;
            _logger = logger;
        }
        public bool Exists(Expression<Func<Domain.Entities.Categories, bool>> filter)
        {
            return this._shopContext.Categories.Any(filter);
        }

        public List<Domain.Entities.Categories> GetAll()
        {
            return this._shopContext.Categories.ToList();
        }

        public List<Domain.Entities.Categories> GetCategoriesById(int Id)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Categories GetEntityBy(int Id)
        {
            Domain.Entities.Categories? category = null;
            try
            {
                category = this._shopContext.Categories.Find(Id);

                if (category is null)
                    throw new CategoriesException("La categoria no se ha encontrado.");
                return category;
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error para encontrar la categoria.", ex.ToString());
            }
            return category;
        }

        public List<Domain.Entities.Categories> GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entities.Categories entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException("La entidad de la categoria no puede ser null.");

                Domain.Entities.Categories? categoriesToRemove = this._shopContext.Categories.Find(entity.Id);

                categoriesToRemove.delete_user = entity.delete_user;
                categoriesToRemove.deleted = entity.deleted;
                categoriesToRemove.delete_date = entity.delete_date;

                _shopContext.Categories.Update(categoriesToRemove);
                this._shopContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error eliminando la categoria");
            }
        }
        
        public void Save(Domain.Entities.Categories entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException("La entidad de la categoria no puede ser nulo.");

                if (Exists(co => co.categoryname.Equals(entity.categoryname)))
                    throw new CategoriesException("La categoria no se encuentra registrada.");

                _shopContext.Categories.Add(entity);
                _shopContext.SaveChanges();
            }
            catch(Exception ex)
            {
                this._logger.LogError("Error agregando la categoria", ex.ToString());
            }
        }
        
        public void Update(Domain.Entities.Categories entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException("La entidad de categorias no puede ser nulo.");

                Domain.Entities.Categories? categoriesToUpdate = this._shopContext.Categories.Find(entity.Id);

                if (categoriesToUpdate == null)
                    throw new CategoriesException("La categoria que desea actualizar no se encuentra registrada.");

                categoriesToUpdate.modify_date = entity.modify_date;

                _shopContext.Categories.Update(categoriesToUpdate);
                _shopContext.SaveChanges();

            }
            catch (Exception ex)
            {
                this._logger.LogError("Error actualizando la categoria.", ex.ToString());
            }
        }
    }
}
