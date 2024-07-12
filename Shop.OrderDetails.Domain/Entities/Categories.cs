
using Shop.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Categories.Domain.Entities
{
    public class Categories : AuditEntity<int>
    {
        [Column("categoryid")]
        public override int Id { get; set; }
    }
}
