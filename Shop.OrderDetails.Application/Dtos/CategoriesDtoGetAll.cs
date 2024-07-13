
namespace Shop.Categories.Application.Dtos
{
    public class CategoriesDtoGetAll
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
