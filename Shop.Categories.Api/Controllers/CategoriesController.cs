using Microsoft.AspNetCore.Mvc;
using Shop.Categories.Application.Contracts;
using Shop.Categories.Application.Dtos;

namespace Shop.Categories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

   
        [HttpGet("GetCategories")]
        public IActionResult Get()
        {
            var result = this.categoriesService.GetCategories();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else 
                return Ok(result);
        }

     
        [HttpGet("GetCategoriesById")]
        public IActionResult Get(int id)
        {
            var result = this.categoriesService.GetCategoryById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

      
        [HttpPost("SaveCategories")]
        public IActionResult Post([FromBody] CategoriesDtoSave dtoSave)
        {
            var result = this.categoriesService.SaveCategories(dtoSave);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        
        [HttpPost("UpdateCategories")]
        public IActionResult Put(CategoriesDtoUpdate dtoUpdate)
        {
            var result = this.categoriesService.UpdateCategories(dtoUpdate);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

       
        [HttpPost("DeleteCategories")]
        public IActionResult Delete(CategoriesDtoRemove dtoRemove)
        {
            var result = this.categoriesService.RemoveCategories(dtoRemove);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }
    }
}
