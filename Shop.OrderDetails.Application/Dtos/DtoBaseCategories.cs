

namespace Shop.Categories.Application.Dtos
{
    public abstract class DtoBaseCategories
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime modify_date { get; set; }
        public int modify_user { get; set; }
        public DateTime creation_date { get; set; }
        public int creation_user { get; set; }

    }
}
