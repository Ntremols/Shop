using Shop.Common.Data.Repository;
using Shop.Suppliers.Domain.Interfaces;
using System.Linq.Expressions;

namespace Shop.Suppliers.Persistence.Repositories
{
    public class SuppliersRepository : ISuppliersRepository
    {
        public bool Exists(Expression<Func<Domain.Entities.Suppliers, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Suppliers> GetAll()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Suppliers GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Suppliers> GetSuppliersByDeparmentId(int deparmentId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entities.Suppliers entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Domain.Entities.Suppliers entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.Suppliers entity)
        {
            throw new NotImplementedException();
        }
    }
}
