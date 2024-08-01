
namespace Shop.Products.Application.Dtos
{
    public class ProductsDtoGetAll
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int creation_user { get; set; }
        public DateTime creation_date { get; set; }
    }
}
