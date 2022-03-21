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
        public int u_id {get; set;}
        public string user_N { get; set; } 
        public string user_LN { get; set; } 
        public bool is_Admin;

        // for passwords table
        public int u_id2 {get; set;}
        public string pass_word { get; set; } 

        // gen vars
        public bool cont;


     public  bool test_char(char i){
                        
                        
                        
                        if (i.Equals('y')== true || i.Equals('Y')==true)
                        {cont = true;}
                                else if(i.Equals('n')==true|| i.Equals('N')==true)
                                {cont=false;}
                        
                        
                

                        
                        return(cont);
                        }


    }   







}