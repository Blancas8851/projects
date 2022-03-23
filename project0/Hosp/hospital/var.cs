using SQL;
using System;


namespace var{
    public  class stuff{

        //for table one patients
        public int Patient_id {get; set;}
        public string P_name { get; set; } 
        public string P_last_name { get; set; } 
        public string Date_enter{ get; set; } 
        public string Date_leave { get; set; } 
        public string ailement{ get; set; } 


        //for table two users
        public int users_id {get; set;}
        public string user_N { get; set; } 
        public string user_pass { get; set; } 
        public bool is_admin;

        

        // gen vars
        public bool cont;
       public string username;
       public string Pass;


     public   bool test_char(char i){
                        
                    bool a = true;
                        while (a)
                        {


                        
                            if (i.Equals('y')== true || i.Equals('Y')==true)
                            {cont = true;
                            a = false;
                            }

                                    else if(i.Equals('n')==true|| i.Equals('N')==true)
                                    
                                    {
                                        cont=false;
                                        a = false;
                                        Console.Clear();
                                        System.Console.ForegroundColor= ConsoleColor.DarkYellow;
                                        
                                        System.Console.ForegroundColor= ConsoleColor.White;;
                                    }
                             else
                             {
                                 System.Console.ForegroundColor= ConsoleColor.Yellow;
                                 System.Console.WriteLine("Not a valid input, please try again");
                                 System.Console.WriteLine("continue? Y/N");
                                 System.Console.ForegroundColor= ConsoleColor.White;
                                    i = Convert.ToChar (Console.ReadLine());
                                 //a = true;
                             }
                             
                        }
                        return(cont);
     }

    }   







}