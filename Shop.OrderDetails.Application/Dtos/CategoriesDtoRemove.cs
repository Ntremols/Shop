
using System.Data;

namespace Shop.Categories.Application.Dtos
{
    public class CategoriesDtoRemove
    {
        public int Id { get; set; }
        public int? DeleteUser {  get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool Deleted { get; set; }
    }
}
