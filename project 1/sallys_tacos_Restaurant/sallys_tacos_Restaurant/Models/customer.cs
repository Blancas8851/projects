using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace sallys_tacos_Restaurant.Models
{
    public class Customer_Details_Model
    {
        #region vars
        public int cust_id { get; set; }
        public string f_name { get; set; }
        public string l_lastname { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string country { get; set; }

        #endregion 



        SqlConnection con = new SqlConnection(@"server = MSI\TRAINER; database= Sally_tacos; integrated security=true");

        #region view customers
        public List<Customer_Details_Model> GetCustomers()
        {
            SqlCommand cmd_allCust = new SqlCommand("select * from customerTable", con);
            List<Customer_Details_Model> clist = new List<Customer_Details_Model>();
            SqlDataReader readAllCust = null;
            try
            {
                con.Open();
                readAllCust = cmd_allCust.ExecuteReader();

                while (readAllCust.Read())
                {
                    clist.Add(new Customer_Details_Model()
                    {
                        cust_id = Convert.ToInt32(readAllCust[0]),
                        f_name = readAllCust[1].ToString(),
                        l_lastname = readAllCust[2].ToString(),
                        address = readAllCust[3].ToString(),
                        state = readAllCust[4].ToString(),
                        country = readAllCust[5].ToString(),
                        city = readAllCust[6].ToString()

                    });


                }


            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readAllCust.Close();
                con.Close();
            }
            return clist;
        }
        #endregion

        #region add
        public string add_Cust(Customer_Details_Model newCust)
        {
            SqlCommand cmd_addCustomer = new SqlCommand("insert into customerTable values( @name, @lastname, @address, @state, @city, @country)", con);
            cmd_addCustomer.Parameters.AddWithValue("@name", newCust.f_name);
            cmd_addCustomer.Parameters.AddWithValue("@lastname", newCust.l_lastname);
            cmd_addCustomer.Parameters.AddWithValue("@address", newCust.address);
            cmd_addCustomer.Parameters.AddWithValue("@state", newCust.state);
            cmd_addCustomer.Parameters.AddWithValue("@city", newCust.city);
            cmd_addCustomer.Parameters.AddWithValue("@country", newCust.country);


            try
            {
                con.Open();
                cmd_addCustomer.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            { 
            con.Close();
            }
            return "Customer Added Successfully";
        }

        #endregion
        public string DeleteCust(int CID)
        {

            SqlCommand cmd_delete = new SqlCommand("delete from customerTable where cust_ID = @CID", con);
            cmd_delete.Parameters.AddWithValue("@CID", CID);
            try
            {
                con.Open();
                cmd_delete.ExecuteNonQuery();
            }
            catch(Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                con.Close();
            }
            return "Customer Deleted Successfully";
        }

        #region Update
        public string UpdateCustomer(Customer_Details_Model update)
        {
            SqlCommand cmd_Cust_update = new SqlCommand("update customerTable set f_name = @fname, l_name = @lname, address = @add, state = @state,country = @country, city= @city where cust_ID = @CID ", con);
            cmd_Cust_update.Parameters.AddWithValue("@fname", f_name);
            cmd_Cust_update.Parameters.AddWithValue("@lname", l_lastname);
            cmd_Cust_update.Parameters.AddWithValue("@add", address);
            cmd_Cust_update.Parameters.AddWithValue("@state", state);
            cmd_Cust_update.Parameters.AddWithValue("@country", country);
            cmd_Cust_update.Parameters.AddWithValue("@city", city);
            cmd_Cust_update.Parameters.AddWithValue("@CID", cust_id);

            try
            {
                con.Open();
                cmd_Cust_update.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
           finally
            {
                con.Close();
            }
            return "customer updated succesfully";
        }

        #endregion

    }
}
