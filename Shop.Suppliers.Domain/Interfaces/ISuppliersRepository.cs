

using Shop.Common.Data.Repository;

namespace Shop.Suppliers.Domain.Interfaces
{
    public interface ISuppliersRepository : IBaseRepository<Entities.Suppliers,int>
    {
        List<Entities.Suppliers> GetSuppliersById(int supplierid);
    }
}
