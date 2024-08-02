

namespace Shop.Categories.Application.Dtos
{
    public abstract class DtoBaseCategories
    {
        public int categoryid { get; set; }
        public string categoryname { get; set; }
        public string description { get; set; }
        public DateTime modify_date { get; set; }
        public int modify_user { get; set; }
        public DateTime creation_date { get; set; }
        public int creation_user { get; set; }

    }
}
