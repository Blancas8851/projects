using System;


namespace Hospital{
        class acct
        {
        #region variables
                public int AccNum { get; set; } 
                public double accbal { get; set;} 
                public bool accIsActive { get; set; }
                public bool cont;
                public string accType;
        public string accName; 
                public string accEmail;

        #endregion



        #region METHODS
                //withdrawning method
                public  double withdraw (double w_balance)
                {
                accbal=accbal - w_balance;
                return(accbal);
                }
                //deposit method
                public double Deposit(double D_bal)
                {
                        accbal=D_bal+accbal;
                        return(accbal);
                }
                //check balance method
                public double balance()
                        {
                                return (accbal);
                        }
                // check account details method
                public string  getAccountDetails() 
                        {
                        string  dets=("Account name: "+ accName 
                                        +"\nAccount number: "+AccNum+
                                        " \nEmail on account: "+ accEmail
                                        +"\nAccount type: "+ accType);

                                return(dets);
                                


                        }

                public  bool continue_B(char i){
                        
                        
                        
                        if (i.Equals('y')== true || i.Equals('Y')==true)
                        {cont = true;}
                                else if(i.Equals('n')==true|| i.Equals('N')==true)
                                {cont=false;}
                        
                        
                

                        
                        return(cont);
                        }
                
                
                
        }
#endregion
}



