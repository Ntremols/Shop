

using Shop.Categories.Domain.Entities;
using Shop.Common.Data.Repository;

namespace Shop.Categories.Domain.Interfaces
{
   public interface ICategoriesRepository : IBaseRepository<Entities.Categories, int>
    {
        List<Entities.Categories> GetCategoriesById(int categoryId);
    }
}
