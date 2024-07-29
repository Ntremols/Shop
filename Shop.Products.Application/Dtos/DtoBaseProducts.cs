

namespace Shop.Products.Application.Dtos
{
    public abstract class DtoBaseProducts
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUser {  get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
    }
}
