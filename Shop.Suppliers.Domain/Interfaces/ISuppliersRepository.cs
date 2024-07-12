

using Shop.Common.Data.Repository;

namespace Shop.Suppliers.Domain.Interfaces
{
    public interface ISuppliersRepository : IBaseRepository<Domain.Entities.Suppliers,int>
    {
        List<Suppliers.Domain.Entities.Suppliers> GetSuppliersByDeparmentId(int deparmentId);
    }
}
