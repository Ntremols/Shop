using Microsoft.AspNetCore.Mvc;
using Shop.Products.Application.Contracts;
using Shop.Products.Application.Dtos;

namespace Shop.Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IproductsServices productsServices;

        public ProductsController(IproductsServices productsServices)
        {
            this.productsServices = productsServices;
        }

       
        [HttpGet("GetProducts")]
        public IActionResult Get()
        {
            var result = this.productsServices.GetProducts();
            if (!result.Success)
            {
                return BadRequest(result);
            }
           
                return Ok(result);
        }

        [HttpPost("GetProductsById")]
        public IActionResult Get(int id)
        {
            var result = this.productsServices.GetProductsById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
          
                return Ok(result);
        }

        [HttpPost("SaveProducts")]
        public IActionResult Post([FromBody] ProductsDtoSave dtoSave)
        {
            var result = this.productsServices.SaveProducts(dtoSave);
            if (!result.Success)
            {
                return BadRequest(result);
            }
          
                return Ok(result);
        }

        [HttpPut("UpdateProducts")]
        public IActionResult Put(ProductsDtoUpdate dtoUpdate)
        {
            var result = this.productsServices.UpdateProducts(dtoUpdate);
            if (!result.Success)
            {
                return BadRequest(result);
            }
      
                return Ok(result);
        }

        [HttpPost("DeleteProducts")]
        public IActionResult Delete(ProductsDtoRemove dtoRemove)
        {
            var result = this.productsServices.RemoveProducts(dtoRemove);
            if (!result.Success)
            {
                return BadRequest(result);
            }
          
                return Ok(result);
        }
    }
}
