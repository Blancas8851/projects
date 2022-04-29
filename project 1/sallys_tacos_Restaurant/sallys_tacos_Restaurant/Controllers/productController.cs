using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using sallys_tacos_Restaurant.Models;
using Microsoft.Extensions.Logging;

namespace sallys_tacos_Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        private readonly ILogger<productController> _logger;

        public productController(ILogger<productController> logger)
        {
            _logger = logger;
        }



        products_Model models = new products_Model();
        [HttpGet]
        [Route("Plist")]

        public IActionResult ProdList()
        {
            return Ok(models.GetProducts());
        }

        [HttpPost]
        [Route("addProd")]
        public IActionResult add_product(string Product_Name, string prod_desc, int prod_qty, double prod_price)
        {
            try
            {
                return Created("", models.add_Prod(Product_Name,prod_desc, prod_qty, prod_price));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("DeleteProduct")]

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



        [HttpPut]
        [Route("UpdateCustomer")]
        public IActionResult UpdateProduct(int prod_id ,string prod_name, string prod_desc, int qty, double prod_price)
        {
            try
            {
                return Accepted(models.UpdateProduct(prod_id, prod_name, prod_desc, qty, prod_price));
            }
            catch (Exception es)
            {
                return BadRequest(es.Message);
            }
        }


















    }
}
