
namespace Shop.Suppliers.Application.Dtos
{
    public class SuppliersDtoRemove
    {
        public int Id { get; set; }
        public int? delete_user { get; set; }
        public DateTime? delete_date { get; set; }
        public bool deleted { get; set; }

    }
}
