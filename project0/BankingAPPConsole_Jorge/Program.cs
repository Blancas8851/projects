using System;
using SQL_CODE;
namespace Hospital
{
    class Program
    {

        private static bool IsServerConnected(string connectionString)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (SqlException)
        {
            return false;
        }
    }
}
        static void Main(string[] args)
        {
           
             Console.WriteLine("~~~~~~~~~~~~~~~~~~Welcome to Hospital Records~~~~~~~~~~~~~~~~~~~~");
             SQL con = new SQL();
                acct user1 = new acct()

                {

                accbal = 3000,
                accName="Jorge",
                accEmail="test@gmail.com",
                accIsActive=true,
                AccNum=12321,
                accType="checkings"
                };
                
                
                bool b_contiune = true;
                bool ans= true;
                int choice =0; 
                char cont='i';
                while(b_contiune)
                {
                    if (ans == true)
                    {
                        Console.Clear();
                        System.Console.WriteLine("what would you like to do today? \n Here are your options"+
                        "\n     1.Create new account \n     2.Check Balance \n     3.Withdraw \n     4.Deposit"+
                        "\n     5.Get Details \n     6.exit");
                        ans = false;

                         choice = Convert.ToInt32( Console.ReadLine());
                    }
                   // int choice = Convert.ToInt32( Console.ReadLine());
                else{choice=6;}
                    switch(choice){

                        case 1: 

                            System.Console.WriteLine("Creating a new account.");
                            System.Console.WriteLine("NAME: ");
                            user1.accName= Console.ReadLine();

                            System.Console.WriteLine("Email: ");
                            user1.accEmail= Console.ReadLine();
                            System.Console.WriteLine("What kind of Account: ");
                            user1.accType= Console.ReadLine();
                            System.Console.WriteLine("Initial balance ");
                            user1.accbal= Convert.ToDouble(Console.ReadLine());
                            System.Console.WriteLine("what would you like your account number to be: ");
                            user1.AccNum= Convert.ToInt32(Console.ReadLine());

                            System.Console.WriteLine("Congratulation your account has been made.");
                            System.Console.WriteLine("continue? Y/N");
                            cont = Convert.ToChar (Console.ReadLine());
                                ans=user1.continue_B(cont);
                   
                        break;


                        case 2: 
                            System.Console.WriteLine("Here is your Balance: " + user1.balance());
                            System.Console.WriteLine("continue? Y/N");
                            cont = Convert.ToChar (Console.ReadLine());
                             ans=user1.continue_B(cont);
                        break;               


                    case 3: 
                            System.Console.WriteLine("How much would you like to withdraw?");
                            double take =Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine(user1.withdraw(take));
    
                            System.Console.WriteLine("continue? Y/N");
                            cont = Convert.ToChar (Console.ReadLine());
                                ans=user1.continue_B(cont);
                        break; 

                    case 4: 
                                System.Console.WriteLine("How much would you like to deposit?");

                            double depo=Convert.ToDouble(Console.ReadLine());
                            System.Console.WriteLine(user1.Deposit(depo));
    
                            System.Console.WriteLine("continue? Y/N");
                            cont = Convert.ToChar (Console.ReadLine());
                                ans=user1.continue_B(cont);
                        break;  


                        case 5: 
                            System.Console.WriteLine("Here are your details");
                            Console.WriteLine(user1.getAccountDetails());


                            System.Console.WriteLine("continue? Y/N");
                            cont = Convert.ToChar (Console.ReadLine());
                                ans=user1.continue_B(cont);
                        break;             


                        case 6: 
                            Console.Clear();
                            System.Console.WriteLine("Thank you for banking with us have a good day!");
                            b_contiune = false;
                            
                        break;                  
                    

                    }
                }
                



             
            
           
 


           
        }
    }
}
