using Microsoft.AspNetCore.Mvc;
using Shop.Categories.Application.Contracts;
using Shop.Categories.Application.Dtos;

namespace Shop.Categories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesServices categoriesServices;

        public CategoriesController(ICategoriesServices categoriesServices)
        {
            this.categoriesServices = categoriesServices;
        }

   
        [HttpGet("GetCategories")]
        public IActionResult Get()
        {
            var result = this.categoriesServices.GetCategories();
            if (!result.Success)
            {
                return BadRequest(result);
            }
     
                return Ok(result);
        }

     
        [HttpGet("GetCategoriesById")]
        public IActionResult Get(int id)
        {
            var result = this.categoriesServices.GetCategoryById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
       
                return Ok(result);
        }

      
        [HttpPost("SaveCategories")]
        public IActionResult Post([FromBody] CategoriesDtoSave dtoSave)
        {
            var result = this.categoriesServices.SaveCategories(dtoSave);
            if (!result.Success)
            {
                return BadRequest(result);
            }
         
                return Ok(result);
        }

        
        [HttpPost("UpdateCategories")]
        public IActionResult Put(CategoriesDtoUpdate dtoUpdate)
        {
            var result = this.categoriesServices.UpdateCategories(dtoUpdate);
            if (!result.Success)
            {
                return BadRequest(result);
            }
           
                return Ok(result);
        }

       
        [HttpPost("DeleteCategories")]
        public IActionResult Delete(CategoriesDtoRemove dtoRemove)
        {
            var result = this.categoriesServices.RemoveCategories(dtoRemove);
            if (!result.Success)
            {
                return BadRequest(result);
            }
        
                return Ok(result);
        }
    }
}
