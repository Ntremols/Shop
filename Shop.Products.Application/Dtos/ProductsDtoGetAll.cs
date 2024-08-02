
namespace Shop.Products.Application.Dtos
{
    public class ProductsDtoGetAll
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public int unitprice { get; set; }
        public int creation_user { get; set; }
        public DateTime creation_date { get; set; }
    }
}
