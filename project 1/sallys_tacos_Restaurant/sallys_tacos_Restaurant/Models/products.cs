using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace sallys_tacos_Restaurant.Models
{
    public class products_Model
    {
        #region product var
        public int prod_id { get; set; }
        public string p_name { get; set; }
        public string prod_desc { get; set; }
        public int prod_qty { get; set; }
        public double prod_price { get; set; }
        #endregion
        SqlConnection con = new SqlConnection(@"server = MSI\TRAINER; database= Sally_tacos; integrated security=true");

        public List <products_Model> GetProducts()
        {
            SqlCommand cmd_ProductList = new SqlCommand("select * from productTable", con);
            List<products_Model> Plist = new List<products_Model>();
            SqlDataReader readAllProd = null;
            try
            {
                con.Open();
                readAllProd=cmd_ProductList.ExecuteReader();

                while (readAllProd.Read())
                {
                    Plist.Add(new products_Model()
                    {
                        prod_id = Convert.ToInt32(readAllProd[0]),
                        p_name = readAllProd[1].ToString(),
                        prod_desc = readAllProd[2].ToString(),
                        prod_qty = Convert.ToInt32(readAllProd[3]),
                        prod_price = Convert.ToDouble(readAllProd[4])

                    });

                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                readAllProd.Close();
                con.Close();
            }
            return Plist;




        }
        
    
        public string add_Prod(string Product_Name, string prod_desc, int prod_qty, double prod_price)
        {
            SqlCommand cmd_addProduct = new SqlCommand("insert into productTable values( @P_name, @product_desc, @P_qty, @P_Cost)", con);
            cmd_addProduct.Parameters.AddWithValue("@P_name", Product_Name);
            cmd_addProduct.Parameters.AddWithValue("@product_desc", prod_desc);
            cmd_addProduct.Parameters.AddWithValue("@P_qty", prod_qty);
            cmd_addProduct.Parameters.AddWithValue("@P_Cost", prod_price);
            try
            {
                con.Open();
                cmd_addProduct.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                con.Close();

            }
            return "product added successfully";
        }

        #region update
        public string UpdateProduct(int prod_id, string prod_name, string prod_desc, int qty, double prod_price)
        {
            SqlCommand cmd_Prod_update = new SqlCommand("update productTable set P_name = @prodname, product_desc = @prod_desc, P_qty = @qty, P_cost = @price where product_Id = @id ", con);
            cmd_Prod_update.Parameters.AddWithValue("@id", prod_id);
            cmd_Prod_update.Parameters.AddWithValue("@prodname", prod_name);
            cmd_Prod_update.Parameters.AddWithValue("@prod_desc", prod_desc);
            cmd_Prod_update.Parameters.AddWithValue("@qty", qty);
            cmd_Prod_update.Parameters.AddWithValue("@price", prod_price);



            try
            {
                con.Open();
                cmd_Prod_update.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                con.Close();
            }
            return "product updated succesfully";
        }
        #endregion


        #region delete product
        public string DeleteProd(int PID)
        {
            SqlCommand cmd_delete = new SqlCommand("delete from productTable where product_Id = @PID", con);
            cmd_delete.Parameters.AddWithValue("@PID", PID);
            try
            {
                con.Open();
                cmd_delete.ExecuteReader();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return "Product has been poofed";

        }
        #endregion






    }
}
