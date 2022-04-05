using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using sallys_tacos_Restaurant.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sallys_tacos_Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustController : ControllerBase
    {
        private readonly ILogger<CustController> _logger;

        public CustController(ILogger<CustController> logger)
        {
            _logger = logger;
        }

        Customer_Details_Model Models = new Customer_Details_Model();
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("clist")]
        public IActionResult CustList()
        {
            return Ok(Models.GetCustomers());
        }

       
        [HttpPost]
        [Route("addCust")]
        public IActionResult add_cust(Customer_Details_Model add_cust)
        {
            try
            {
                return Created("", Models.add_Cust(add_cust));
            }
            catch(System.Exception es)
            {
                return BadRequest(es.Message);
            }
        }

        [HttpDelete]
        [Route("deleteProduct")]
        public IActionResult Cust_delete(int ID)
        {
            try
            {
                return Accepted(Models.DeleteCust(ID));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }
        }
        
        [HttpPut]
        [Route("UpdateCustomer")]
        public IActionResult UpdateCustomer(Customer_Details_Model update)
        {
            try
            {
                return Accepted(Models.UpdateCustomer(update));
            }
            catch(Exception es)
            {
                return BadRequest(es.Message);
            }
        }




    }
}
