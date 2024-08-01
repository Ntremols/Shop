
namespace Shop.Suppliers.Application.Dtos
{
    public class DtoBaseSuppliers : DtoBase
    {
        public int supplierid { get; set; }
        public string companyname { get; set; }
        public string contactname { get; set; }
        public DateTime creation_date { get; set; }
        public int creation_user {  get; set; }
   

    }
}
