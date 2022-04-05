using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace sallys_tacos_Restaurant.Models
{
    public class makeOrders_model
    {
        #region Vars
        public int order_id { get; set; }
        public int cust_id { get; set; }
        public int prod_id { get; set; }
        public string date { get; set; }
        public int prod_qty { get; set; }
    

        #endregion 
        SqlConnection con = new SqlConnection(@"server = MSI\TRAINER; database= Sally_tacos; integrated security=true");



        public string make_order(int c_id, int prod_id, string date, int prod_QTY)
        {
            SqlCommand cmd_MakeOrder = new SqlCommand("insert into orders values (@custID, @prodID,@date,@qty)", con);
            cmd_MakeOrder.Parameters.AddWithValue("@custID", c_id);
            cmd_MakeOrder.Parameters.AddWithValue("@prodID", prod_id);
            cmd_MakeOrder.Parameters.AddWithValue("@date", date);
            cmd_MakeOrder.Parameters.AddWithValue("@qty", prod_QTY);

            try
            {
                con.Open();
                cmd_MakeOrder.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                con.Close();
            }
            return "order made succesfully";

        }
        public string delete_order(int ID )
        {
         SqlCommand cmd_del_order = new SqlCommand("delete from orders where product_Id = @id", con);
            cmd_del_order.Parameters.AddWithValue("@id", ID);
            
            try
            {
                con.Open();
                cmd_del_order.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception (ex.Message);

            }
            finally
            {
                con.Close ();

            }
            return "Order Deleted";

        }




    }

}
