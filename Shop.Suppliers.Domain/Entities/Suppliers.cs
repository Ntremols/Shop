

using Shop.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Suppliers.Domain.Entities
{
    public class Suppliers : AuditEntity <int>
    {
        [Column("supplierid")]
        public override int Id { get; set; }
    }
}
