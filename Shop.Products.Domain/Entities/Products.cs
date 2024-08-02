﻿

using Shop.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Products.Domain.Entities
{
    public class Products : AuditEntity<int>
    {
        [Column("productid")]
        public override int Id { get ; set ; }
        public string productname {  get; set; }
        public int unitprice { get; set; }
    }
}
