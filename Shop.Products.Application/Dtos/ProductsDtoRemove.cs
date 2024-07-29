



namespace Shop.Products.Application.Dtos
{
    public class ProductsDtoRemove
    {
        public int Id { get; set; }
        public int? DeleteUser { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
