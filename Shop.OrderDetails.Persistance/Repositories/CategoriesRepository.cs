
using System.ComponentModel;
using System.Linq.Expressions;
using Shop.Categories.Domain.Entities;
using Shop.Categories.Domain.Interfaces;

namespace Shop.Categories.Persistence.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        public bool Exists(Expression<Func<Domain.Entities.Categories, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Categories> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Categories> GetCategoriesByDeparmentId(int deparmentId)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Categories GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entities.Categories entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Domain.Entities.Categories entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.Categories entity)
        {
            throw new NotImplementedException();
        }
    }
}
