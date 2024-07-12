

using Shop.Categories.Domain.Entities;
using Shop.Common.Data.Repository;

namespace Shop.Categories.Domain.Interfaces
{
   public interface ICategoriesRepository : IBaseRepository<Domain.Entities.Categories,int>
    {
        List<Categories.Domain.Entities.Categories> GetCategoriesByDeparmentId(int deparmentId);
    }
}
