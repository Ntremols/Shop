



namespace Shop.Products.Application.Dtos
{
    public class ProductsDtoRemove
    {
        public int Id { get; set; }
        public int? delete_user { get; set; }
        public bool deleted { get; set; }
        public DateTime delete_date { get; set; }
    }
}
