namespace Shop.WebApp.Models.Suppliers.Result
{
    public class BaseResult<TModel>
    {
        public string message { get; set; }
        public bool success { get; set; }
        public TModel? result { get; set; }
    }
}
