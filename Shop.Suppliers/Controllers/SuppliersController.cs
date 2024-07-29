using Microsoft.AspNetCore.Mvc;
using Shop.Suppliers.Application.Contracts;
using Shop.Suppliers.Application.Dtos;

namespace Shop.Suppliers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISuppliersService suppliersService;

        public SuppliersController(ISuppliersService suppliersService)
        {
            this.suppliersService = suppliersService;
        }


        [HttpGet("GetSuppliers")]
        public IActionResult Get()
        {
            var result = this.suppliersService.GetSuppliers();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpGet("GetSuppliersById")]
        public IActionResult Get(int id)
        {
            var result = this.suppliersService.GetSuppliersById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost("SaveSuppliers")]
        public IActionResult Post([FromBody] SuppliersDtoSave dtoSave)
        {
            var result = this.suppliersService.SaveSuppliers(dtoSave);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost("UpdateSuppliers")]
        public IActionResult Put(SuppliersDtoUpdate dtoUpdate)
        {
            var result = this.suppliersService.UpdateSuppliers(dtoUpdate);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost("DeleteSuppliers")]
        public IActionResult Delete(SuppliersDtoRemove dtoRemove)
        {
            var result = this.suppliersService.RemoveSuppliers(dtoRemove);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }
    }
}
