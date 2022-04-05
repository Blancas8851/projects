using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_webapi.Models;


namespace products_webapi.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        #region first greet
        //[HttpGet]
        //public IActionResult Greet()
        //{


        //    return Ok("welcome to webapi - RESTFUL services");
        //}
        #endregion
        #region pass a paramter
        //[HttpGet]
        //public IActionResult GreetUser(string guestName)
        //{
        //    return Ok("Welcome : " + guestName);
        //}
        #endregion
        #region return products array
        //[HttpGet]
        //public IActionResult GetProductList()
        //{
        //    string[] products = new string[10];
        //    products[0] = "pepsi";
        //    products[1] = "coke";
        //    products[2] = "Iphone";
        //    products[3] = "fossil";
        //    products[4] = "dell lattitude";
        //    products[5] = "burger";
        //    products[6] = "pizza";
        //    products[7] = "strawberry milk shake";
        //    products[8] = "mango shake";
        //    products[9] = "airpods";
        //    return Ok(products);
        //}
        #endregion
        [HttpGet]
        public IActionResult Getproductinformation()
        {
            ProductsModel model = new ProductsModel();
            return Ok(model.GetProductsInfo());
        }


    }
}
