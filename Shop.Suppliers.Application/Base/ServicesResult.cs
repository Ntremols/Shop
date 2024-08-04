
namespace Shop.Suppliers.Application.Base
{
    public class ServicesResult<TData>
    {
        public ServicesResult() => this.Success = true;
        public string? Message { get; set; }
        public bool Success { get; set; }
        public TData? Result { get; set; }
    }
}
