using System;
using System.Data.SqlClient;
namespace SQL_CODE{
    class SQL{



    // connection string to swl database
    SqlConnection con = new SqlConnection(@"server=MSI\TRAINER ;database=Hop;integrated security=true");    




    public string add_New_record (SQL newrecord)
    {
        SqlCommand cmd_addrecord = new SqlCommand ("insert into patient values( @p_name , @P_last_name, @Date_enter, @Date_leave,@ailement)",con);
        cmd_addrecord.Parameters.AddWithValue("@P_name", newrecord.P_name);


     try
                {
                    con.Open();
                    cmd_addrecord.ExecuteNonQuery();                    
                }
                catch(SqlException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return "Product Added Successfully";



    }   
    }

}