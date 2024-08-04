namespace Shop.WebApp.Models.Suppliers
{
    public class SuppliersUpdateModel
    {
        public int modify_user { get; set; }
        public DateTime modify_date { get; set; }
        public int supplierid { get; set; }
        public string companyname { get; set; }
        public string contactname { get; set; }
        public DateTime creation_date { get; set; }
        public int creation_user { get; set; }
    }
}
