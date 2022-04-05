using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using sallys_tacos_Restaurant.Models;

namespace sallys_tacos_Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        products_Model models = new products_Model();
        [HttpGet]
        [Route("Plist")]

        public IActionResult ProdList()
        {
            return Ok(models.GetProducts());
        }

        [HttpPost]
        [Route("addProd")]
        public IActionResult add_product(products_Model add_product)
        {
            try
            {
                return Created("", models.add_Prod(add_product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("DeleteProduc")]

        public IActionResult delete_product( int id)
        {
            try
            {
                return Accepted(models.DeleteProd(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






















    }
}
