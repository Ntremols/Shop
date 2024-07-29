
namespace Shop.Suppliers.Application.Dtos
{
    public class SuppliersDtoRemove
    {
        public int Id { get; set; }
        public int? DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool Deleted { get; set; }

    }
}
