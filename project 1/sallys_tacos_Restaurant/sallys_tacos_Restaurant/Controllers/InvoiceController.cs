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
    public class InvoiceController : ControllerBase
    {


        private readonly ILogger<InvoiceController> _logger;
        public InvoiceController(ILogger<InvoiceController> logger)
        {
            _logger = logger;
        }

        
        invoice inv = new invoice();
     

        [HttpGet]
        [Route("invoice")]
        public IActionResult invs(int customer_id, int order_id)
        {
            
            return Ok(inv.invoices(customer_id, order_id));
        }



    }
  
}
