

namespace Shop.Categories.Application.Dtos
{
    public abstract class DtoBaseCategories
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifyUser { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }

    }
}
