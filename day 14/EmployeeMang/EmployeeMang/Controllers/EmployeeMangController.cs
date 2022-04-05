using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeMang.Models;

namespace EmployeeMang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMangController : ControllerBase
    {



        EmployeeDetailsModel model = new EmployeeDetailsModel();
        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee(EmployeeDetailsModel newEmployee)
        {
            try
            {
                return Created("", model.AddEmployee(newEmployee));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }
        }


        [HttpDelete]
        [Route("deleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                return Accepted(model.DeleteEmployee(id));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }
        }



        [HttpPut]
        [Route("updateEmployee")]
        public IActionResult UpdateEmployee(EmployeeDetailsModel updates)
        {
            try
            {
                return Accepted(model.UpdateEmployee(updates));
            }
            catch (System.Exception es)
            {

                return BadRequest(es.Message);
            }
        }

        [HttpGet]
        [Route("Employeedetail")]
        public IActionResult GetEmployeeById(int empNo)
        {
            try
            {
                return Ok(model.GetEmployeeDetails(empNo));
            }
            catch (System.Exception es)
            {

                return BadRequest(es.Message);
            }
        }







    }
}
