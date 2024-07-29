
namespace Shop.Products.Application.Dtos
{
    public class ProductsDtoGetAll
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
