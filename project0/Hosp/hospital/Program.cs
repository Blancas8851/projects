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

              Console.WriteLine("~~~~~~~~~~~~~~~~~~Welcome to Hospital Records~~~~~~~~~~~~~~~~~~~~");
              stuff user1 = new stuff();

                while(b_contiune)
                {
                    if (ans == true)
                    {
                       // Console.Clear();

                        System.Console.WriteLine("Are you an admin?");
                         char admin_test =Convert.ToChar( Console.ReadLine());
                         bool ans2=user1.test_char(admin_test);

                            if (ans2== false){
                                System.Console.WriteLine("Your options are\n 1.Review all current records \n 2.sort records \n 3.exit");
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
                                        System.Console.WriteLine("_________________________________");
                                        System.Console.WriteLine("Patient ID: " + item.Patient_id);
                                        System.Console.WriteLine("Patient first name: " + item.P_name);
                                        System.Console.WriteLine("Patient last name: "+ item.P_last_name);
                                        System.Console.WriteLine("Date Patient entered: " + item.Date_enter);
                                        System.Console.WriteLine("Date Patient left: " + item.Date_leave);
                                        System.Console.WriteLine("Patients Ailment: " +item.ailement);
                                      }
                                            


                                     System.Console.WriteLine("continue? Y/N");
                                     cont = Convert.ToChar (Console.ReadLine());
                                     ans=user1.test_char(cont);
                                    break;
                                    #endregion
                                    case 2:
                                    System.Console.WriteLine("how would you like to sort? \n 1. filtering \n 2. grouping \n 3.exit");
                                    choice = Convert.ToInt32( Console.ReadLine());
                                            switch(choice)
                                        {

                                                case 1:
                                                //filter

                                                System.Console.WriteLine("continue? Y/N");
                                            cont = Convert.ToChar(Console.ReadLine());
                                            ans=user1.test_char(cont);
                                                break;

                                                case 2:
                                                // groupby

                                                        System.Console.WriteLine("continue? Y/N");
                                                    cont = Convert.ToChar (Console.ReadLine());
                                                    ans=user1.test_char(cont);
                                            
                                                break;
                                                 case 3:
                                                    System.Console.WriteLine("Thank you have a good day");
                                                    b_contiune=false;
                                                    break;

                                        } 
                                        break;

                                    case 3:
                                    System.Console.WriteLine("Thank you have a good day");
                                    b_contiune=false;
                                    break;

                                }

                            }
                            else if (ans2 == true) {

                            
                        System.Console.WriteLine("Welcome admin, what would you like to do today? \n Here are your options"+
                        "\n     1.Create new record \n     2.Review current Records \n     3.Change Existing records \n     4.delete records"+
                        "\n     5.update for just leaving date records \n     6.exit");
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
                              System.Console.WriteLine("continue? Y/N");
                                                    cont = Convert.ToChar (Console.ReadLine());
                                                    ans=user1.test_char(cont);
                       
                             break;
                             
                            #endregion
                             
                             
                             #region case 2 Show all
                             case 2:
                                System.Console.WriteLine("Lets review our records.");
                                 System.Console.WriteLine("here are all current records: ");
                                    //select all records from the database
                                    sql select_all = new sql();
                                      List<sql> lst= select_all.select_all();
                                      foreach(var item in lst )
                                      {
                                        System.Console.WriteLine("_________________________________");
                                        System.Console.WriteLine("Patient ID: " + item.Patient_id);
                                        System.Console.WriteLine("Patient first name: " + item.P_name);
                                        System.Console.WriteLine("Patient last name: "+ item.P_last_name);
                                        System.Console.WriteLine("Date Patient entered: " + item.Date_enter);
                                        System.Console.WriteLine("Date Patient left: " + item.Date_leave);
                                        System.Console.WriteLine("Patients Ailment: " +item.ailement);
                                      }
                                            


                                     System.Console.WriteLine("continue? Y/N");
                                     cont = Convert.ToChar (Console.ReadLine());
                                     ans=user1.test_char(cont);
                                break;
                                #endregion
                                case 3:
                                System.Console.WriteLine("lets change existing records.");
                                 
                                 
                                  System.Console.WriteLine("Enter new Name");
                                    string U_name =Convert.ToString( Console.ReadLine());
                                 System.Console.WriteLine("Enter new Last Name");
                                    string U_lastname =Convert.ToString( Console.ReadLine());
                                System.Console.WriteLine("new date entered");
                                    string U_date_e =Convert.ToString( Console.ReadLine());
                                 System.Console.WriteLine("new date left");
                                    string U_date_l =Convert.ToString( Console.ReadLine());
                                System.Console.WriteLine("new Enter ailement");
                                    string U_ailement =Convert.ToString( Console.ReadLine());
                                
                                
                                
                                  System.Console.WriteLine("What Patient id do you wish to alter?");
                                 int U_id =Convert.ToInt32( Console.Read());
                                
                                
                                
                                sql update = new sql();
                                  

                                update.Patient_id = U_id;
                                update.P_name = U_name;
                                update.P_last_name = U_lastname;
                                update.Date_enter = U_date_e;
                                update.Date_leave = U_date_l;
                                update.ailement = U_ailement;
                                Console.WriteLine(update.change_record(update));

                                 System.Console.WriteLine("continue? Y/N");
                                    cont = Convert.ToChar (Console.ReadLine());
                                                    ans=user1.test_char(cont);
                                break;
                                #region case 4 delete
                                case 4:
                                System.Console.WriteLine("what patinet id would you like to delete");
                                int del= Convert.ToInt32(Console.ReadLine());
                                sql delete = new sql();
                                delete.delete_record(del);

                                System.Console.WriteLine("continue? Y/N");
                                     cont = Convert.ToChar (Console.ReadLine());
                                     ans=user1.test_char(cont);
                                break;
                                #endregion
                                case 5:
                                break;
                              case 6:
                                    System.Console.WriteLine("Thank you have a good day");
                                    b_contiune=false;
                             break;
                            
                         }

                         

                            }
                    }
                  
                else{ b_contiune=false;}
                       
             
             
         }
        System.Console.WriteLine(sql.IsServerConnected());

    }
         }
         
}
