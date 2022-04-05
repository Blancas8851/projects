using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace sallys_tacos_Restaurant.Models
{
    public class orders_model
    {
        #region Vars
        public int order_id { get; set; }
        public int cust_id { get; set; }
        public  int prod_id { get; set; }
        public  string date { get; set; }
        public int prod_qty { get; set; }
        public string F_name { get; set; }
        internal string L_name { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string country { get; set; } 
        public string city { get; set; }
        public string p_name { get;set; }   
        public string prod_desc { get; set; }
        public double prod_price { get; set; }
        public int order_qty { get; set; }

        #endregion 
        SqlConnection con = new SqlConnection(@"server = MSI\TRAINER; database= Sally_tacos; integrated security=true");

        public List<orders_model> AllOrders()
        {
            SqlCommand cmd_allOrders = new SqlCommand(" select orders.order_id,customerTable.*, productTable.*,orders.order_date, orders.qty_ordered" +
                " from orders " +
                " inner join customerTable on orders.cust_id = customerTable.cust_ID " +
                "inner join productTable on orders.product_id = productTable.product_Id", con);
            List<orders_model> OrderList = new List<orders_model>();
            SqlDataReader readAllOrders = null;
            
            try
            {
                con.Open();
                readAllOrders = cmd_allOrders.ExecuteReader();

                while (readAllOrders.Read())
                {
                    OrderList.Add(new orders_model()
                    {
                        order_id = readAllOrders.GetInt32(0),
                        cust_id = readAllOrders.GetInt32(1),
                        F_name = readAllOrders.GetString(2),
                        L_name = readAllOrders.GetString(3),
                        address = readAllOrders.GetString(4),
                        state=readAllOrders.GetString(5),   
                        country = readAllOrders.GetString(6),
                        city = readAllOrders.GetString(7),
                        prod_id =  readAllOrders.GetInt32(8),
                        p_name = readAllOrders.GetString(9),
                        prod_desc = readAllOrders.GetString(10),
                        prod_qty = readAllOrders.GetInt32(11),
                        prod_price = readAllOrders.GetDouble(12),
                        date =Convert.ToString( readAllOrders.GetDateTime(13)),
                        order_qty = readAllOrders.GetInt32(14)



                    });
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readAllOrders.Close();
                con.Close();
            }
        
            return OrderList;
        
        }


        //public string make_order(orders_model neworder)
        //{
        //    SqlCommand cmd_MakeOrder = new SqlCommand("insert into orders values (@custID, @prodID,@date,@qty)", con);
        //    cmd_MakeOrder.Parameters.AddWithValue("@custID", neworder.cust_id);
        //    cmd_MakeOrder.Parameters.AddWithValue("@prodID", neworder.prod_id);
        //    cmd_MakeOrder.Parameters.AddWithValue("@date", neworder.date);
        //    cmd_MakeOrder.Parameters.AddWithValue("@qty", neworder.prod_qty);

        //    try
        //    {
        //        con.Open();
        //        cmd_MakeOrder.ExecuteNonQuery();

        //    }
        //    catch(Exception ex)
        //    {
        //        throw new Exception(ex.Message);

        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return "order made succesfully";

        //}




    }

}
