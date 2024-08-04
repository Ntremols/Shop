
namespace Shop.Suppliers.Application.Dtos
{
    public class SuppliersDtoRemove : DtoBaseSuppliers
    {
        public int? modify_user { get; set; }
        public DateTime modify_date { get; set; }
        public int? delete_user { get; set; }
        public DateTime? delete_date { get; set; }
        public bool deleted { get; set; }

    }
}
