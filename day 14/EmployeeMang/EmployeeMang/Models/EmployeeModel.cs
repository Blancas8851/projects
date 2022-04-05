using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace EmployeeMang.Models
{
    public class EmployeeDetailsModel
    {
        #region columns
        public int empNo { get; set; }
        public string empName { get; set; }
        public string empDesination { get; set; }
        public int empSalary { get; set; }
        public bool empIsPermenant { get; set; }
        #endregion
        SqlConnection con = new SqlConnection(@"server=MSI\TRAINER ;database=EmployeeManagement ;integrated security=true");

        #region READ

        public EmployeeDetailsModel GetEmployeeDetails(int empNo)
        {

            SqlCommand cmd_searchById = new SqlCommand("select * from Employee where empNo=@empNo", con);
            cmd_searchById.Parameters.AddWithValue("@empNo", empNo);
            SqlDataReader read_Employee = null;
            EmployeeDetailsModel pr = new EmployeeDetailsModel();
            try
            {
                con.Open();
                read_Employee = cmd_searchById.ExecuteReader();

                if (read_Employee.Read())
                {
                    pr.empNo = Convert.ToInt32(read_Employee[0]);
                    pr.empName = read_Employee[1].ToString();
                    pr.empDesination = read_Employee[2].ToString();
                    pr.empSalary = Convert.ToInt32(read_Employee[3]);
                    pr.empIsPermenant = Convert.ToBoolean(read_Employee[4]);

                }
                else
                {
                    throw new Exception("Employee Not Found");
                }
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                read_Employee.Close();
                con.Close();
            }
            return pr;
        }
        #endregion




        #region adding employee
        public string AddEmployee(EmployeeDetailsModel newEmployee)
        {
            SqlCommand cmd_addEmployee = new SqlCommand("insert into Employee values(@pName,@empDes,@empSal,@empPermenant)", con);
            //cmd_addEmployee.Parameters.AddWithValue("@pId",newEmployee.EmployeeId); -- identity Column
            cmd_addEmployee.Parameters.AddWithValue("@pName", newEmployee.empName);
            cmd_addEmployee.Parameters.AddWithValue("@empDes", newEmployee.empDesination);
            cmd_addEmployee.Parameters.AddWithValue("@empSal", newEmployee.empSalary);
            cmd_addEmployee.Parameters.AddWithValue("@empPermenant", newEmployee.empIsPermenant);
            

            try
            {
                con.Open();
                cmd_addEmployee.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);

            }
            finally
            {
                con.Close();
            }
            return "Employee Added Successfully";
        }
        #endregion
        #region delete employee

        

        public string DeleteEmployee(int empNo)
        {
            SqlCommand cmd_delete = new SqlCommand("delete from Employee where empNo = @empNo", con);
            cmd_delete.Parameters.AddWithValue("@empNo", empNo);
            try
            {
                con.Open();
                cmd_delete.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                con.Close();
            }
            return "Employee Deleted Successfully";
        }
        #endregion

        #region update
        public string UpdateEmployee(EmployeeDetailsModel updates)
        {

            SqlCommand cmd_updateEmployee = new SqlCommand("update Employee set empName=@pName, empDesination=@empDes, empSalary= @empSal, empIsPermenant=@empPermenant where empNo =@empNo", con);
            cmd_updateEmployee.Parameters.AddWithValue("@pName", updates.empName);
            cmd_updateEmployee.Parameters.AddWithValue("@empDes", updates.empDesination);
            cmd_updateEmployee.Parameters.AddWithValue("@empSal", updates.empSalary);
            cmd_updateEmployee.Parameters.AddWithValue("@empPermenant", updates.empIsPermenant);
            cmd_updateEmployee.Parameters.AddWithValue("@empNo", updates.empNo);

            try
            {
                con.Open();
                cmd_updateEmployee.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                con.Close();
            }
            return "Employee update successfull";
        }

        #endregion 





    }
}
