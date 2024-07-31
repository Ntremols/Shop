
namespace Shop.Suppliers.Application.Dtos
{
    public class DtoBaseSuppliers : DtoBase
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser {  get; set; }
   

    }
}
