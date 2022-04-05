using System.Collections.Generic;

namespace products_webapi.Models
{
    public class ProductsModel
    {

        #region Product Properities
        public int pId { get; set; }
        public string pName { get; set; }
        public double pPrice { get; set; }
        public bool pInStock { get; set; }
        public string pCategory { get; set; }
        public int pAvailableQTY { get; set; }
        #endregion


        public ProductsModel GetProductsInfo()
        {
            return new ProductsModel()
            {
                pId = 101,
                pName = "greent tea",
                pPrice = 8,
                pInStock = true,
                pCategory = "health drink",
                pAvailableQTY = 20

            };
        }
    }
}
