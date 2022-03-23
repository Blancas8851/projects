using System;
using SQL;
using var;

using System.Data.SqlClient;
using System.Collections.Generic;
namespace hospital
{
    class Program
    {
        

  static void Main(string[] args)
         {  
             // VARIABLES
                
                bool b_contiune = true;
                bool ans= true;
                
                int choice =0; 
                char cont='i';
                bool test = false;
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~Welcome to Hospital Records~~~~~~~~~~~~~~~~~~~~");
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
              stuff user1 = new stuff();

                while(b_contiune)
                {
                    if (ans == true)
                    {
                       // Console.Clear();
                       //varibles that need to be reset every run
                        bool response = true;
                        string statemnt1= "";
                        string statement2 = "";
                        System.Console.ForegroundColor= ConsoleColor.Yellow;
                        System.Console.WriteLine("Are you an admin?");
                        sql test1_ = new sql();
                        
                         char admin_test =Convert.ToChar( Console.ReadLine());
                         bool ans2=user1.test_char(admin_test); 
                         if (ans2== true)
                         {
                                System.Console.WriteLine("username: ");
                                System.Console.ForegroundColor= ConsoleColor.White;
                                user1.username = Convert.ToString(Console.ReadLine());
                                System.Console.ForegroundColor= ConsoleColor.Yellow;
                                System.Console.WriteLine("password: ");
                                System.Console.ForegroundColor= ConsoleColor.White;
                                user1.Pass= Convert.ToString(Console.ReadLine());
                        
                            test =test1_.admin(user1.username, user1.Pass);
                         }
                          // push both values to test if right
                          
                         
                             if (ans2== false ||test ==false)
                             {
                                 Console.Clear();
                                 System.Console.ForegroundColor= ConsoleColor.Yellow;
                                        System.Console.WriteLine("Your options are:\n 1.Review all current records \n 2.search records \n 3.exit");
                                        System.Console.ForegroundColor= ConsoleColor.White;
                                        choice = Convert.ToInt32(Console.ReadLine());

                                        switch(choice){
                                                #region  case 1 show all
                                            case 1:
                                            System.Console.WriteLine("here are all current records: ");
                                            //select all records from the database
                                            sql select_all = new sql();
                                            List<sql> lst= select_all.select_all();
                                            foreach(var item in lst )
                                            {
                                                System.Console.ForegroundColor= ConsoleColor.Blue;
                                                System.Console.WriteLine("_________________________________");
                                                System.Console.WriteLine("Patient ID: " + item.Patient_id);
                                                System.Console.WriteLine("Patient first name: " + item.P_name);
                                                System.Console.WriteLine("Patient last name: "+ item.P_last_name);
                                                System.Console.WriteLine("Date Patient entered: " + item.Date_enter);
                                                System.Console.WriteLine("Date Patient left: " + item.Date_leave);
                                                System.Console.WriteLine("Patients Ailment: " +item.ailement);
                                            }
                                                    

                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            System.Console.WriteLine("continue? Y/N");
                                            Console.ForegroundColor= ConsoleColor.White;
                                            cont = Convert.ToChar (Console.ReadLine());
                                            ans=user1.test_char(cont);
                                            break;
                                            #endregion
                                            case 2:
                                            //System.Console.WriteLine("how would you like to sort? \n 1. filtering \n 2. grouping \n 3.exit");
                                            
                                                 
                                                        //filter
                                                        sql filt = new sql();
                                                        System.Console.WriteLine("Welcome to search, what would you like to search for? ");
                                                        while(response){
                                                            System.Console.ForegroundColor= ConsoleColor.Yellow;
                                                        System.Console.WriteLine("Column choices are: Name | Last Name | Date entered | Date Left| Ailment");
                                                         System.Console.ForegroundColor= ConsoleColor.White;
                                                         statemnt1= Convert.ToString(Console.ReadLine());

                                                            if(statemnt1 == "Name" || statemnt1 == "name")
                                                            {
                                                                statemnt1 = "P_name";
                                                                response = false;
                                                            }                        
                                                            else if(statemnt1 == "Last Name" || statemnt1 == "last name")
                                                            {
                                                                statemnt1 = "P_last_name";
                                                                response = false;
                                                            }                             
                                                            else if(statemnt1 == "Date entered" || statemnt1 =="date entered")
                                                            {
                                                                statemnt1= "Date_enter";
                                                                response = false;
                                                            }   
                                                            else if(statemnt1 == "date left" || statemnt1 =="Date Left")
                                                            {
                                                                statemnt1= "Date_leave";
                                                                response = false;
                                                            } 
                                                             else if(statemnt1 == "Ailement" || statemnt1 =="ailment")
                                                            {
                                                                statemnt1= "ailement";
                                                                response = false;
                                                            } 
                                                            else if(statemnt1=="ID" || statemnt1=="id")
                                                            {
                                                                statemnt1 = "Patient_id";
                                                                response = false;

                                                            }
                                                            else
                                                            {
                                                                System.Console.WriteLine("not a proper response");
                                                            }
                                                        }
                                                        System.Console.WriteLine("What would you like to filter for?");
                                                        statement2 = Convert.ToString(Console.ReadLine());
                                                        System.Console.WriteLine("here are all records in "+statemnt1+" with search "+statement2+": ");
                                            //select all records from the database
                                           
                                            List<sql> lst_filt= filt.filter(statemnt1,statement2 );
                                                var testing = lst_filt;
                                                if (testing.Count == 0)
                                                            {
                                                                // Add new item
                                                                System.Console.WriteLine("No results for "+ statement2); 
                                                            }

                                              else {  
                                            foreach(var item1 in lst_filt )
                                            {
                                                System.Console.ForegroundColor= ConsoleColor.Blue;
                                                System.Console.WriteLine("_________________________________");
                                                System.Console.WriteLine("Patient ID: " + item1.Patient_id);
                                                System.Console.WriteLine("Patient first name: " + item1.P_name);
                                                System.Console.WriteLine("Patient last name: "+ item1.P_last_name);
                                                System.Console.WriteLine("Date Patient entered: " + item1.Date_enter);
                                                System.Console.WriteLine("Date Patient left: " + item1.Date_leave);
                                                System.Console.WriteLine("Patients Ailment: " +item1.ailement);
                                            }
                                              }
                                                System.Console.ForegroundColor= ConsoleColor.White;
                                                Console.ForegroundColor= ConsoleColor.Yellow;
                                                        System.Console.WriteLine("continue? Y/N");
                                                        Console.ForegroundColor= ConsoleColor.White;
                                                    cont = Convert.ToChar(Console.ReadLine());
                                                    ans=user1.test_char(cont);
                                                        

                                                
                                            break;

                                            case 3:
                                             Console.Clear();
                                
                                             System.Console.WriteLine("Thank you have a good day");
                                             b_contiune=false;
                                            break;

                                        }

                            
                            }
                        
                           else if (test1_.admin(user1.username, user1.Pass)==true ) 
                          { 
                            Console.Clear();
                            System.Console.ForegroundColor= ConsoleColor.Yellow;
                        System.Console.WriteLine("Welcome admin, what would you like to do today? \n Here are your options:"+
                        "\n     1.Create new record \n     2.Review current Records \n     3.Change Existing records \n     4.delete records"+
                        "\n     5.update for just leaving date records \n     6.filter \n     7.exit");
                        System.Console.ForegroundColor= ConsoleColor.White;
                        ans = false;

                         choice = Convert.ToInt32( Console.ReadLine());

                         switch(choice)
                         {
                             #region  case 1 new record

                             case 1:
                                System.Console.WriteLine("lets insert new data");
                                 System.Console.WriteLine("Enter Name");
                                    string name =Console.ReadLine();
                                 System.Console.WriteLine("Enter Last Name");
                                    string lastname =Console.ReadLine();
                                System.Console.WriteLine("date entered");
                                    string date_e =Console.ReadLine();
                                 System.Console.WriteLine("date left");
                                    string date_l =Console.ReadLine();
                                System.Console.WriteLine("Enter ailement");
                                    string ailement =Console.ReadLine();
                                sql newRecord = new sql();
                                newRecord.P_name = name;
                                newRecord.P_last_name = lastname;
                                newRecord.Date_enter = date_e;
                                newRecord.Date_leave = date_l;
                                newRecord.ailement = ailement;
                            System.Console.WriteLine(newRecord.add_New_record(newRecord));
                            Console.ForegroundColor= ConsoleColor.Yellow;
                              System.Console.WriteLine("continue? Y/N");
                              Console.ForegroundColor= ConsoleColor.White;
                                                    cont = Convert.ToChar (Console.ReadLine());
                                                    ans=user1.test_char(cont);
                       
                             break;
                             
                            #endregion
                             
                             
                             #region case 2 Show all
                             case 2:
                             Console.ForegroundColor= ConsoleColor.Yellow;
                                System.Console.WriteLine("Lets review our records.");
                                 System.Console.WriteLine("here are all current records: ");
                                 Console.ForegroundColor= ConsoleColor.White;
                                    //select all records from the database
                                    sql select_all = new sql();
                                      List<sql> lst= select_all.select_all();
                                      foreach(var item in lst )
                                      {
                                        Console.ForegroundColor= ConsoleColor.Blue;
                                        System.Console.WriteLine("_________________________________");
                                        System.Console.WriteLine("Patient ID: " + item.Patient_id);
                                        System.Console.WriteLine("Patient first name: " + item.P_name);
                                        System.Console.WriteLine("Patient last name: "+ item.P_last_name);
                                        System.Console.WriteLine("Date Patient entered: " + item.Date_enter);
                                        System.Console.WriteLine("Date Patient left: " + item.Date_leave);
                                        System.Console.WriteLine("Patients Ailment: " +item.ailement);
                                        Console.ForegroundColor= ConsoleColor.White;
                                      }
                                            

                                    Console.ForegroundColor= ConsoleColor.Yellow;
                                     System.Console.WriteLine("continue? Y/N");
                                     Console.ForegroundColor= ConsoleColor.White;
                                     cont = Convert.ToChar (Console.ReadLine());
                                     ans=user1.test_char(cont);
                                break;
                                #endregion
                                
                                #region case 3 alter records
                                case 3:
                                Console.ForegroundColor= ConsoleColor.Yellow;
                                System.Console.WriteLine("lets change existing records.");
                                 
                                 
                                  System.Console.WriteLine("Enter new Name");
                                  Console.ForegroundColor= ConsoleColor.White;
                                    string U_name =Convert.ToString( Console.ReadLine());
                                    Console.ForegroundColor= ConsoleColor.Yellow;
                                 System.Console.WriteLine("Enter new Last Name");
                                 Console.ForegroundColor= ConsoleColor.White;
                                    string U_lastname =Convert.ToString( Console.ReadLine());
                                    Console.ForegroundColor= ConsoleColor.Yellow;
                                System.Console.WriteLine("new date entered");
                                Console.ForegroundColor= ConsoleColor.White;
                                    string U_date_e =Convert.ToString( Console.ReadLine());
                                    Console.ForegroundColor= ConsoleColor.Yellow;
                                 System.Console.WriteLine("new date left");
                                 Console.ForegroundColor= ConsoleColor.White;
                                    string U_date_l =Convert.ToString( Console.ReadLine());
                                    Console.ForegroundColor= ConsoleColor.Yellow;
                                System.Console.WriteLine("new Enter ailement");
                                Console.ForegroundColor= ConsoleColor.White;
                                    string U_ailement =Convert.ToString( Console.ReadLine());
                                
                                
                                Console.ForegroundColor= ConsoleColor.Yellow;
                                  System.Console.WriteLine("What Patient id do you wish to alter?");
                                  Console.ForegroundColor= ConsoleColor.White;
                                 int U_id =Convert.ToInt32( Console.ReadLine());
                                
                                
                                
                                sql update = new sql();
                                  

                                update.Patient_id = U_id;
                                update.P_name = U_name;
                                update.P_last_name = U_lastname;
                                update.Date_enter = U_date_e;
                                update.Date_leave = U_date_l;
                                update.ailement = U_ailement;
                                Console.WriteLine(update.change_record(update));

                                Console.ForegroundColor= ConsoleColor.Yellow;
                                 System.Console.WriteLine("continue? Y/N");
                                 Console.ForegroundColor= ConsoleColor.White;
                                    cont = Convert.ToChar (Console.ReadLine());
                                                    ans=user1.test_char(cont);
                                break;

                                #endregion
                                #region case 4 delete
                                case 4:
                                Console.ForegroundColor= ConsoleColor.Yellow;
                                System.Console.WriteLine("what patinet id would you like to delete");
                                Console.ForegroundColor= ConsoleColor.White;
                                int del= Convert.ToInt32(Console.ReadLine());
                                sql delete = new sql();
                                delete.delete_record(del);
                                Console.ForegroundColor= ConsoleColor.Yellow;
                                System.Console.WriteLine("continue? Y/N");
                                Console.ForegroundColor= ConsoleColor.White;
                                     cont = Convert.ToChar (Console.ReadLine());
                                     ans=user1.test_char(cont);
                                break;
                                #endregion
                               
                               #region  case 5 Patient just left
                                case 5:
                                sql update2 = new sql();
                                Console.ForegroundColor= ConsoleColor.Yellow;
                                System.Console.WriteLine("Patient just left lets update that.");
                                System.Console.WriteLine("lets change existing records.");
                                 
                                System.Console.WriteLine("patient ID of who left");
                                Console.ForegroundColor= ConsoleColor.White;
                                int just_left=Convert.ToInt32(Console.ReadLine());
                                
                                Console.WriteLine(update2.just_left(just_left));
                                Console.ForegroundColor= ConsoleColor.Yellow;
                                 System.Console.WriteLine("continue? Y/N");
                                 Console.ForegroundColor= ConsoleColor.White;
                                    cont = Convert.ToChar (Console.ReadLine());
                                                    ans=user1.test_char(cont);
                                break;

                                #endregion
                             #region case 6 search
                             case 6:
                            //                 System.Console.WriteLine("how would you like to sort? \n 1. filtering \n 2. grouping \n 3.exit");
                            //                 choice = Convert.ToInt32( Console.ReadLine());
                                                    
                                                        //filter
                                                        sql filt = new sql();
                                                        System.Console.WriteLine("Welcome to search, what would you like to search for? ");
                                                        while(response){
                                                            System.Console.ForegroundColor= ConsoleColor.Yellow;
                                                        System.Console.WriteLine("Column choices are: Name | Last Name | Date entered | Date Left| Ailment");
                                                            System.Console.ForegroundColor= ConsoleColor.White;
                                                         statemnt1= Convert.ToString(Console.ReadLine());

                                                            if(statemnt1 == "Name" || statemnt1 == "name")
                                                            {
                                                                statemnt1 = "P_name";
                                                                response = false;
                                                            }                        
                                                            else if(statemnt1 == "Last Name" || statemnt1 == "last name")
                                                            {
                                                                statemnt1 = "P_last_name";
                                                                response = false;
                                                            }                             
                                                            else if(statemnt1 == "Date entered" || statemnt1 =="date entered")
                                                            {
                                                                statemnt1= "Date_enter";
                                                                response = false;
                                                            }   
                                                            else if(statemnt1 == "date left" || statemnt1 =="Date Left")
                                                            {
                                                                statemnt1= "Date_leave";
                                                                response = false;
                                                            } 
                                                             else if(statemnt1 == "Ailement" || statemnt1 =="ailment")
                                                            {
                                                                statemnt1= "ailement";
                                                                response = false;
                                                            } 
                                                            else if(statemnt1=="ID" || statemnt1=="id")
                                                            {
                                                                statemnt1 = "Patient_id";
                                                                response = false;

                                                            }
                                                            else
                                                            {
                                                                System.Console.WriteLine("not a proper response");
                                                            }
                                                        }
                                                        System.Console.WriteLine("What would you like to filter for?");
                                                        statement2 = Convert.ToString(Console.ReadLine());
                                                        
                                                        System.Console.WriteLine("here are all records in "+statemnt1+" with search "+statement2+": ");
                                            //select all records from the database
                                           
                                            List<sql> lst_filt= filt.filter(statemnt1,statement2 );
                                                var testing = lst_filt;
                                                if (testing.Count == 0)
                                                            {
                                                                // Add new item
                                                                System.Console.WriteLine("No results for "+ statement2); 
                                                            }

                                              else {  
                                            foreach(var item1 in lst_filt )
                                            {
                                                System.Console.ForegroundColor= ConsoleColor.Blue;
                                                System.Console.WriteLine("_________________________________");
                                                System.Console.WriteLine("Patient ID: " + item1.Patient_id);
                                                System.Console.WriteLine("Patient first name: " + item1.P_name);
                                                System.Console.WriteLine("Patient last name: "+ item1.P_last_name);
                                                System.Console.WriteLine("Date Patient entered: " + item1.Date_enter);
                                                System.Console.WriteLine("Date Patient left: " + item1.Date_leave);
                                                System.Console.WriteLine("Patients Ailment: " +item1.ailement);
                                            }
                                              }
                                                    System.Console.ForegroundColor= ConsoleColor.Yellow;
                                                        System.Console.WriteLine("continue? Y/N");
                                                        Console.ForegroundColor= ConsoleColor.White;
                                                    cont = Convert.ToChar(Console.ReadLine());
                                                    ans=user1.test_char(cont);
                                                        break;

                                                      
                                                #endregion
                              case 7:
                                    Console.Clear();
                                    
        
                                    System.Console.WriteLine("Thank you have a good day");
                                    b_contiune=false;
                             break;
                            
                         }

                            }

                    }
                    
                  
                 else{ b_contiune=false;}
                } 
             
             
         }
       // System.Console.WriteLine(sql.IsServerConnected());
    
    }
         
         
}
