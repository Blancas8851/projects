using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace sallys_tacos_Restaurant.Models
{
    public class invoice
    {
        public int QTY { get; set; }
        public double Price { get; set; }
        public double total_price { get; set; }
        public int order_ID { get; set; }   
        public string date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Productname { get; set; } 
        public string product_desc { get; set; }

        SqlConnection con = new SqlConnection(@"server = MSI\TRAINER; database= Sally_tacos; integrated security=true");

        public List<invoice> invoices(int cust_ID, int Order_id)
        {
            SqlCommand get_invoice = new SqlCommand("select orders.order_id,orders.order_date,customerTable.f_name,customerTable.l_name ,productTable.P_name,productTable.product_desc,productTable.P_cost, orders.qty_ordered,qty_ordered *productTable.P_cost AS total_cost" +
            " from orders " +
            " inner join customerTable on orders.cust_id = customerTable.cust_ID " +
            "inner join productTable on orders.product_id = productTable.product_Id " +
            "where customerTable.cust_ID = @custID and orders.order_id = @O_ID", con);

            get_invoice.Parameters.AddWithValue("@custID", cust_ID);
            get_invoice.Parameters.AddWithValue("@O_ID", Order_id);
            List<invoice> invoices = new List<invoice>();
            SqlDataReader readINV = null;

            try
            {
                con.Open();
                readINV = get_invoice.ExecuteReader();
                while (readINV.Read())
                {
                    invoices.Add(new invoice()
                    {
                        order_ID = Convert.ToInt32(readINV[0]),
                        date = readINV[1].ToString(),
                        FirstName = readINV[2].ToString(),
                        LastName = readINV[3].ToString(),
                        Productname = readINV[4].ToString(),
                        product_desc = readINV[5].ToString(),
                        Price = Convert.ToDouble(readINV[6]),
                        QTY = Convert.ToInt32(readINV[7]),
                        total_price = Convert.ToDouble(readINV[8])
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readINV.Close();
                con.Close();
            }
            return invoices;
        }
      

    }
}
