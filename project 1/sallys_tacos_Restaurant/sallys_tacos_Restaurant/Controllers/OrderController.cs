using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using sallys_tacos_Restaurant.Models;
namespace sallys_tacos_Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger; 
        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        orders_model model = new orders_model();
        makeOrders_model make = new makeOrders_model();
        [HttpGet]
        [Route("Orders")]
        public IActionResult allOrders()
        {
            return Ok(model.AllOrders());
        }

        [HttpPost]
        /// <summary>
        /// get name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("makeOrder")]
        public IActionResult Make_Order(int c_id,int prod_id,string date, int prod_QTY)
        {
            try
            {
                return Created("", make.make_order(c_id , prod_id , date , prod_QTY));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        [HttpDelete]
        [Route("deleteOrder")]
        public IActionResult Delete_Order(int ID )
        {
            try
            {
                return Accepted(make.delete_order(ID));
            }
            catch (System.Exception ex)

            {
                return BadRequest(ex.Message);
            }
        }





    }
}
