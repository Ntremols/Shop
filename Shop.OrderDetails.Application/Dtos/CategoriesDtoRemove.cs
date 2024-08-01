
using System.Data;

namespace Shop.Categories.Application.Dtos
{
    public class CategoriesDtoRemove
    {
        public int Id { get; set; }
        public int? delete_user {  get; set; }
        public DateTime? delete_date { get; set; }
        public bool deleted { get; set; }
    }
}
