namespace Shop.WebApp.Models
{
    public class SuppliersGetModel
    {
        public int supplierid { get; set; }
        public string companyname { get; set; }
        public string contactname { get; set; }
        public int creation_user { get; set; }
        public DateTime creation_date { get; set; }
    }
}
