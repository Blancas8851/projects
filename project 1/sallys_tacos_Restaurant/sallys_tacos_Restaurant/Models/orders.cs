using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace sallys_tacos_Restaurant.Models
{
    public class Orders_model
    {
        #region Vars
        public int order_id { get; set; }
        public int cust_id { get; set; }
        public  int prod_id { get; set; }
        public  string date { get; set; }
        public int prod_qty { get; set; }
        public string F_name { get; set; }
        public string L_name { get; set; }
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
        #region show all orders
        public List<Orders_model> AllOrders()
        {
            SqlCommand cmd_allOrders = new SqlCommand(" select orders.order_id,customerTable.*, productTable.*,orders.order_date, orders.qty_ordered" +
                " from orders " +
                " inner join customerTable on orders.cust_id = customerTable.cust_ID " +
                "inner join productTable on orders.product_id = productTable.product_Id", con);
            List<Orders_model> OrderList = new List<Orders_model>();
            SqlDataReader readAllOrders = null;
            
            try
            {
                con.Open();
                readAllOrders = cmd_allOrders.ExecuteReader();

                while (readAllOrders.Read())
                {
                    OrderList.Add(new Orders_model()
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
        #endregion

        #region show by customer id
        public List<Orders_model> custOrders(int custid)
        {
            SqlCommand cmd_someOrders = new SqlCommand(" select orders.order_id,customerTable.*, productTable.*,orders.order_date, orders.qty_ordered" +
                " from orders " +
                " inner join customerTable on orders.cust_id = customerTable.cust_ID " +
                "inner join productTable on orders.product_id = productTable.product_Id "+
                "where customerTable.cust_ID = @custID", con);
            cmd_someOrders.Parameters.AddWithValue("@custID", custid);
            List<Orders_model> OrderSOMEList = new List<Orders_model>();
            SqlDataReader readSomeOrders = null;
            try
            {
                con.Open();
                readSomeOrders = cmd_someOrders.ExecuteReader();

                while (readSomeOrders.Read())
                {
                    OrderSOMEList.Add(new Orders_model()
                    { 
                        cust_id = readSomeOrders.GetInt32(1),
                        order_id = readSomeOrders.GetInt32(0),
                        F_name = readSomeOrders.GetString(2),
                        L_name = readSomeOrders.GetString(3),
                        address = readSomeOrders.GetString(4),
                        state = readSomeOrders.GetString(5),
                        country = readSomeOrders.GetString(6),
                        city = readSomeOrders.GetString(7),
                        prod_id = readSomeOrders.GetInt32(8),
                        p_name = readSomeOrders.GetString(9),
                        prod_desc = readSomeOrders.GetString(10),
                        prod_qty = readSomeOrders.GetInt32(11),
                        prod_price = readSomeOrders.GetDouble(12),
                        date = Convert.ToString(readSomeOrders.GetDateTime(13)),
                        order_qty = readSomeOrders.GetInt32(14)



                    });
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readSomeOrders.Close();
                con.Close();
            }

            return OrderSOMEList;




        }
        #endregion



    }

}
