
using System.Data;

namespace Shop.Categories.Application.Dtos
{
    public abstract class DtoBase
    {
        public int? modify_user { get; set; }
        public DateTime?  MofidyDate { get; set; }
    }
}
