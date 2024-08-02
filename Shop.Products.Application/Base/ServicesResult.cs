
namespace Shop.Products.Application.Base
{
    public class ServicesResult
    {
        public ServicesResult() => this.Success = true;
        public string? Message { get; set; }
        public bool Success { get; set; }
        public dynamic? Result { get; set; }
    }
}
