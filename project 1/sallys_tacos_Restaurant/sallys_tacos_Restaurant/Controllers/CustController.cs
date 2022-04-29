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


        [HttpGet]
        [Route("Search Customer")]
        public IActionResult Cust_search(int id)
        {
            return Ok(Models.GetCustomers_by(id));  
        }

       
        [HttpPost]
        [Route("addCust")]
        public IActionResult add_cust( string f_name, string l_lastname, string address, string state, string city, string country)
        {
            try
            {
                return Created("", Models.add_Cust(f_name,l_lastname,address, state,city,country));
            }
            catch(System.Exception es)
            {
                return BadRequest(es.Message);
            }
        }

        [HttpDelete]
        [Route("deleteCustomer")]
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
        public IActionResult UpdateCustomer(int cust_id, string f_name, string l_lastname, string address, string city, string state, string country)
        {
            try
            {
                return Accepted(Models.UpdateCustomer(cust_id,f_name,l_lastname,address,city,state,country));
            }
            catch(Exception es)
            {
                return BadRequest(es.Message);
            }
        }




    }
}
