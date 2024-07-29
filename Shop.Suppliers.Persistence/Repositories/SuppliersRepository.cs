using Shop.Common.Data.Repository;
using Shop.Suppliers.Domain.Interfaces;
using Shop.Suppliers.Persistence.Context;
using System.Linq.Expressions;
using Shop.Suppliers.Persistence.Exceptions;
using Microsoft.Extensions.Logging;

namespace Shop.Suppliers.Persistence.Repositories
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly ShopContext _shopContext;

        private readonly ILogger<SuppliersRepository> _logger;
        public SuppliersRepository(ShopContext context, ILogger<SuppliersRepository> logger)
        {
            _shopContext = context;
            _logger = logger;
        }
        public bool Exists(Expression<Func<Domain.Entities.Suppliers, bool>> filter)
        {
            return this._shopContext.Suppliers.Any(filter);
        }

        public List<Domain.Entities.Suppliers> GetAll()
        {
            return this._shopContext.Suppliers.ToList();
        }

        public List<Domain.Entities.Suppliers> GetSuppliersById(int Id)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Suppliers GetEntityBy(int Id)
        {
            Domain.Entities.Suppliers? suppliers = null;
            try
            {
                suppliers = this._shopContext.Suppliers.Find(Id);

                if (suppliers is null)
                    throw new SuppliersException("El suplidor no se ha encontrado.");
                return suppliers;
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error para encontrar el suplidor.", ex.ToString());
            }
            return suppliers;
        }

        public void Remove(Domain.Entities.Suppliers entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException("La entidad del suplidor no puede ser null.");

                Domain.Entities.Suppliers? suppliersToRemove = this._shopContext.Suppliers.Find(entity.Id);

                suppliersToRemove.DeleteUser = entity.DeleteUser;
                suppliersToRemove.Deleted = entity.Deleted;
                suppliersToRemove.DeleteDate = entity.DeleteDate;

                _shopContext.Suppliers.Update(suppliersToRemove);
                this._shopContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error eliminando el suplidor.");
            }
        }

        public void Save(Domain.Entities.Suppliers entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException("La entidad del suplidor no puede ser nulo.");

                if (Exists(co => co.CompanyName.Equals(entity.CompanyName)))
                    throw new SuppliersException("El suplidor no se encuentra registrada.");

                _shopContext.Suppliers.Add(entity);
                _shopContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error agregando El suplidor.", ex.ToString());
            }
        }

        public void Update(Domain.Entities.Suppliers entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException("La entidad del suplidor no puede ser nulo.");

                Domain.Entities.Suppliers? suppliersToUpdate = this._shopContext.Suppliers.Find(entity.Id);

                if (suppliersToUpdate == null)
                    throw new SuppliersException("El suplidor que desea actualizar no se encuentra registrada.");

                suppliersToUpdate.ModifyDate = entity.ModifyDate;

                _shopContext.Suppliers.Update(suppliersToUpdate);
                _shopContext.SaveChanges();

            }
            catch (Exception ex)
            {
                this._logger.LogError("Error actualizando el suplidor", ex.ToString());
            }

        }
    }
}
