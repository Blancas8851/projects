using System;
using System.Data.SqlClient;
using var;
using System.Data;
using System.Collections.Generic;
namespace SQL
{
    public class sql:stuff{
     // connection string to swl database
    SqlConnection con = new SqlConnection(@"server=MSI\TRAINER ;database=Hop;integrated security=true");    
    
    


    // METHODS DOWN UNDER

public string add_New_record (sql newrecord)
    {
        SqlCommand cmd_addrecord = new SqlCommand ("insert into Pat values( @p_name , @P_last_name, @Date_enter, @Date_leave,@ailement)",con);
        cmd_addrecord.Parameters.AddWithValue("@P_name", newrecord.P_name);
        cmd_addrecord.Parameters.AddWithValue("@P_last_name", newrecord.P_last_name);
        cmd_addrecord.Parameters.AddWithValue("@date_enter", newrecord.Date_enter);
        cmd_addrecord.Parameters.AddWithValue("@Date_leave",newrecord.Date_leave);
        cmd_addrecord.Parameters.AddWithValue("@ailement",newrecord.ailement);


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
                return "record Added Successfully";



    }   

public string delete_record(int id)
{
    SqlCommand cmd_delete_record = new SqlCommand("delete from Pat where Patient_id =@pid ",con);
    cmd_delete_record.Parameters.AddWithValue("@pid",id);


    try
    {
        con.Open();
        cmd_delete_record.ExecuteNonQuery();

    }
    catch(System.Exception es)
    {
        System.Console.WriteLine(es.Message);

    }
    finally 
    {
        con.Close();
    }
    return "successful record deletion";

}       

public string change_record(sql change_R)
{
 SqlCommand cmd_addrecord = new SqlCommand ("update Pat set P_name = @p_name , P_last_name= @P_last_name, Date_enter = @Date_enter,Date_leave= @Date_leave,ailement = @ailement where Patient_id = @U_id",con);
        
        cmd_addrecord.Parameters.AddWithValue("@P_name", change_R.P_name);
        cmd_addrecord.Parameters.AddWithValue("@P_last_name", change_R.P_last_name);
        cmd_addrecord.Parameters.AddWithValue("@date_enter",change_R.Date_enter);
        cmd_addrecord.Parameters.AddWithValue("@Date_leave",change_R.Date_leave);
        cmd_addrecord.Parameters.AddWithValue("@ailement", change_R.ailement);
        cmd_addrecord.Parameters.AddWithValue("@U_id",change_R.Patient_id);
      

    
    try
    {
        con.Open();
        cmd_addrecord.ExecuteNonQuery();

    }
    catch(System.Exception es)
    {
        System.Console.WriteLine(es.Message);

    }
    finally 
    {
        con.Close();
    }
    return "successful change";
}


public  List<sql> select_all()
{
    
    
    SqlCommand cmd_selectall = new SqlCommand("select * from Pat",con);
    SqlDataReader _read= null;
    List <sql> lst_records = new List<sql>();
        try
                {
                      con.Open();
                      _read = cmd_selectall.ExecuteReader();
                    while (_read.Read())
                     {
                    lst_records.Add(new sql()
                {
                Patient_id = Convert.ToInt32(_read[0]),
                P_name = Convert.ToString(_read[1]),
                P_last_name = Convert.ToString(_read[2]),
                Date_enter= Convert.ToString(_read[3]),
                Date_leave = Convert.ToString(_read[4]),
                ailement = Convert.ToString(_read[5])


                });

                     }
               

                }
                catch(SqlException es)
                {
                throw new Exception(es.Message);           
                }
                finally
                {
                    _read.Close();
                    con.Close();
                }
                return lst_records;


    

}












  public static bool IsServerConnected(){
      using( SqlConnection con = new SqlConnection(@"server=MSI\TRAINER ;database=Hop;integrated security=true"))
      {
        
            try
            {
                con.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
                {
                    con.Close();
                }
          
      }



        }
    
    

    }





}