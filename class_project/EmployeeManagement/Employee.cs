using System;

class Employee
{


public  int empNo { get; set; }
public string empName { get; set; }
public int empSalary { get; set; }
public bool isPermenant { get; set; }


public double getbonus(int percent)
{
   double bonus = empSalary * (Convert.ToDouble(percent)/100); 

return (bonus);
}




}