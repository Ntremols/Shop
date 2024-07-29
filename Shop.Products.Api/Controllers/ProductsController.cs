using Microsoft.AspNetCore.Mvc;
using Shop.Products.Application.Contracts;
using Shop.Products.Application.Dtos;

namespace Shop.Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

       
        [HttpGet("GetProducts")]
        public IActionResult Get()
        {
            var result = this.productsService.GetProducts();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost("GetProductsById")]
        public IActionResult Get(int id)
        {
            var result = this.productsService.GetProductsById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost("SaveProducts")]
        public IActionResult Post([FromBody] ProductsDtoSave dtoSave)
        {
            var result = this.productsService.SaveProducts(dtoSave);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPut("UpdateProducts")]
        public IActionResult Put(ProductsDtoUpdate dtoUpdate)
        {
            var result = this.productsService.UpdateProducts(dtoUpdate);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost("DeleteProducts")]
        public IActionResult Delete(ProductsDtoRemove dtoRemove)
        {
            var result = this.productsService.RemoveProducts(dtoRemove);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }
    }
}
