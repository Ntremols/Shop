

namespace Shop.Products.Application.Dtos
{
    public abstract class DtoBaseProducts
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public DateTime? modify_date { get; set; }
        public int? modify_user {  get; set; }
        public DateTime creation_date { get; set; }
        public int creation_user { get; set; }
    }
}
