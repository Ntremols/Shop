using Shop.Common.Data.Repository;
using Shop.Suppliers.Domain.Interfaces;
using Shop.Suppliers.Persistence.Context;
using System.Linq.Expressions;
using Shop.Suppliers.Persistence.Exceptions;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;

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

        public List<Domain.Entities.Suppliers> GetEntityById(int Id)
        {

            /*if (suppliers == null)
            {
                throw new SuppliersException($"El suplidor no se ha encontrado.{Id}");
            }
            var suppliersList = new List<Domain.Entities.Suppliers>{ suppliers };*/

            return _shopContext.Suppliers.Where(s => s.Id.Equals(Id)).ToList();
        }
        

        public void Remove(Domain.Entities.Suppliers entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException("La entidad del suplidor no puede ser null.");

                Domain.Entities.Suppliers? suppliersToRemove = this._shopContext.Suppliers.Find(entity.Id);

                suppliersToRemove.delete_user = entity.delete_user;
                suppliersToRemove.deleted = entity.deleted;
                suppliersToRemove.delete_date = entity.delete_date;

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

                if (Exists(co => co.companyname.Equals(entity.companyname)))
                    throw new SuppliersException("El suplidor se encuentra registrado.");

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

                suppliersToUpdate.companyname = entity.companyname;
                suppliersToUpdate.contactname = entity.contactname;
                suppliersToUpdate.contacttitle = entity.contacttitle;
                suppliersToUpdate.address = entity.address;
                suppliersToUpdate.city = entity.city;
                suppliersToUpdate.region = entity.region;
                suppliersToUpdate.postalcode = entity.postalcode;
                suppliersToUpdate.country = entity.country;
                suppliersToUpdate.phone = entity.phone;
                suppliersToUpdate.fax = entity.fax;
                suppliersToUpdate.modify_user = entity.modify_user;
                suppliersToUpdate.modify_date = entity.modify_date;

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
