﻿

namespace Shop.Suppliers.Application.Dtos
{
    public class SuppliersDtoSave : DtoBaseSuppliers
    {
        public DateTime creation_date { get; set; }
        public int creation_user { get; set; }
    }
}
