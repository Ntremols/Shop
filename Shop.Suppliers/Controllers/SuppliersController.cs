using Microsoft.AspNetCore.Mvc;
using Shop.Suppliers.Application.Contracts;
using Shop.Suppliers.Application.Dtos;

namespace Shop.Suppliers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : Controller
    {
        private readonly ISuppliersServices suppliersServices;

        public SuppliersController(ISuppliersServices suppliersServices)
        {
            this.suppliersServices = suppliersServices;
        }


        [HttpGet("GetSuppliers")]
        public IActionResult Get()
        {
            var result = this.suppliersServices.GetSuppliers();
            if (!result.Success)
            {
                return BadRequest(result);
            }
           
                return Ok(result);
        }

        [HttpGet("GetSuppliersById")]
        public IActionResult Get(int id)
        {
            var result = this.suppliersServices.GetSuppliersById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
           
                return Ok(result);
        }

        [HttpPost("SaveSuppliers")]
        public IActionResult Post([FromBody] SuppliersDtoSave dtoSave)
        {
            var result = this.suppliersServices.SaveSuppliers(dtoSave);
            if (!result.Success)
            {
                return BadRequest(result);
            }
           
                return Ok(result);
        }

        [HttpPost("UpdateSuppliers")]
        public IActionResult Put(SuppliersDtoUpdate dtoUpdate)
        {
            var result = this.suppliersServices.UpdateSuppliers(dtoUpdate);
            if (!result.Success)
            {
                return BadRequest(result);
            }
           
                return Ok(result);
        }

        [HttpPost("DeleteSuppliers")]
        public IActionResult Delete(SuppliersDtoRemove dtoRemove)
        {
            var result = this.suppliersServices.RemoveSuppliers(dtoRemove);
            if (!result.Success)
            {
                return BadRequest(result);
            }
          
                return Ok(result);
        }
    }
}
