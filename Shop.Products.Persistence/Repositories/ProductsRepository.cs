using Shop.Products.Domain.Interfaces;
using System.Linq.Expressions;

namespace Shop.Products.Persistence.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        public bool Exists(Expression<Func<Domain.Entities.Products, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Products> GetAll()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Products GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Products> GetProductsByDeparmentId(int deparmentId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entities.Products entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Domain.Entities.Products entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.Products entity)
        {
            throw new NotImplementedException();
        }
    }
}
