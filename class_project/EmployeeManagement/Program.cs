using System;

namespace EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee Emp = new Employee()
            {
                empName="Raymond",
                empNo=12345,
                empSalary = 30000,
                isPermenant = true       
            }; 
            Console.WriteLine("How much bonus");
           double o = Emp.getbonus(Convert.ToInt32( Console.ReadLine()));
           System.Console.WriteLine("your bonus is: " + o);

        }
    }
}
