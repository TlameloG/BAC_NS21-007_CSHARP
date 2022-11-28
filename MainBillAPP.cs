

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MYBILL;

internal class WaterBill
{
    public static void Main()
    {
        using (StreamWriter Logger = new StreamWriter("DEBUGGER.txt", true))
        {
            Logger.WriteLine("><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
            Logger.WriteLine("#> New Session Created!---|| " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff"));
            Logger.WriteLine(" ");
        }
        Method_Ex Customer1 = new Method_Ex();  // CREATE OUR TWO OBJECTS
        Method_Ex Customer2 = new Method_Ex();
        string FirstInput;
    SystemLoop: //WE LOOP TO THIS POINT WHEN USER DECIDES TO LOGUT HIS ACCOUNT
        FirstInput = Method_Ex.Logins(); //CALL METHOD TO CHOOSE IF WE CREATE A NEW ACCOUNT OR NOT

        if (FirstInput == "2")   // CREATE AND STORE A NEW ACCOUNT INTO THE SYSTEM
        {
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("                            You have chosen option 2  ");
            Console.WriteLine("                       Press any Key to Start Registration .");
            Console.Write("                                          ->");
            Console.ReadKey();
            Console.Clear();

            if (Customer1.FirstName == " ")      // STORE INFORMATION TO CUSTOMER1 OBJECT IF SLOT IS EMPTY
            {
                var Account_create = Method_Ex.SIGNUP_Customer();
                Customer1.UserType = Account_create.Item1;
                Customer1.FirstName = Account_create.Item2;
                Customer1.Lastname = Account_create.Item3;
                Customer1.PlotNumber = Account_create.Item4;
                Customer1.Location = Account_create.Item5;
                Customer1.UserName = Account_create.Item6;
                Customer1.UserPassword = Account_create.Item7;
            }
            else if (Customer2.FirstName == " ") // STORE INFORMATION TO CUSTOMER1 OBJECT IF SLOT IS EMPTY
            {
                var Account_create = Method_Ex.SIGNUP_Customer();
                Customer2.UserType = Account_create.Item1;
                Customer2.FirstName = Account_create.Item2;
                Customer2.Lastname = Account_create.Item3;
                Customer2.PlotNumber = Account_create.Item4;
                Customer2.Location = Account_create.Item5;
                Customer2.UserName = Account_create.Item6;
                Customer2.UserPassword = Account_create.Item7;
            }
            else // DISPLAY WHEN BOTH CUSTOMER 1 AND CUSTOMER 2 SLOTS ARE OCCUPIED 
            {
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine("                                  Storage Full !");
                Console.WriteLine("                                  Proceed To Login.  ");
            }
        }
        else // The Customer already has an account 
        {
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("                             You have chosen option 1  ");
            Console.WriteLine("                           Press any Key to Start Login .");
            Console.Write("                                           ->");
            Console.ReadKey();
            Console.Clear();
        }
        // Login SAVED CUSTOMERS
        //==========================================================================================================================
        String InputUserName;
        String InputUserPassword;
        Console.WriteLine("----------------------------------------------------------------------------------");//INPUT USERNAME AND PASSWORD
        Console.WriteLine("                                   WELCOME ");
        Console.WriteLine("      ");
        Console.Write("                                  Username -> ");
        InputUserName = Console.ReadLine();
        Console.Write("                                  Password -> ");
        InputUserPassword = Console.ReadLine();
        Console.Clear();

        int resulT; // we capture results  with this variable
        int CustomerPath = 0; // WE USE THIS VARIABLE TO NAVIGATE COMPILER TO THE REQUIRED USER ACCOUNT
        int trials = 1; //WE USE THIS VARIABLE AS A SIGNAL TO EXIT LOOP BELOW

        do   //LOOP UNTIL USERNAME AND PASSWORD ARE CORRECT
        {
            if (InputUserName == Customer1.UserName && InputUserPassword == Customer1.UserPassword)
            {
                resulT = 1; CustomerPath = 1;
            }
            //DISTINGUISH IF USER IS CUSTOMER 1 OR CUSTOMER 2
            else if (InputUserName == Customer2.UserName && InputUserPassword == Customer2.UserPassword)
            {
                resulT = 1;
                CustomerPath = 2;
            }
            else
            {
                Console.WriteLine("----------------------------------------------------------------------------------");      //RE-ENTER USERNAME AND PASSWORD
                Console.WriteLine("                             Trials: " + trials);
                Console.WriteLine("                     Invalid UserName Or Password!!    TRY AGAIN");
                Console.Write("                                  Username -> ");
                InputUserName = Console.ReadLine();
                Console.Write("                                  Password -> ");
                InputUserPassword = Console.ReadLine();
                trials++;
                resulT = 0;
                Console.Clear();
            }

        } while (resulT == 0);

        //===================================================================================================================================        
        if (CustomerPath == 1)
            Method_Ex.Get_bill(Customer1.FirstName, Customer1.Lastname, Customer1.Location, Customer1.PlotNumber, Customer1.UserType);
        //WE PASS ARGUMENTS TO GET_BILL METHOD WHICH WILL PRINT TO CONSOLE AND TEXT FILE
        else if (CustomerPath == 2)
            Method_Ex.Get_bill(Customer2.FirstName, Customer2.Lastname, Customer2.Location, Customer2.PlotNumber, Customer2.UserType);

        else
        {
            Console.WriteLine("----------------------------------------------------------------------------------");                        //WE PRINT INVALID IF CUSTOMER 1 IS NEITHER 1 NOR 2
            Console.Write("                                         INVALID INPUT !!!!   ");
            Console.WriteLine("                                 Press any key to proceed");
            Console.WriteLine("----------------------------------------------------------------------------------");
        }
        Console.WriteLine("    ");
        Console.WriteLine("             Enter 0 to logout your Account or any other key to exit system        ");                          //ASKING USER TO LOGUT ACCOUNT 
        Console.Write("                                          ->");
        string systemloop = Console.ReadLine();
        if (systemloop == "0")
        {
            using (StreamWriter Logger = new StreamWriter("DEBUGGER.txt", true))
            {
                Logger.WriteLine("#> " + "User Signed-out!---|| " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff"));
                Logger.WriteLine(" ");
            }
            Console.Clear();
            goto SystemLoop;                  // LOOP TO BEGINING OF SYSTEM 
        }
        else
        {
            using (StreamWriter Logger = new StreamWriter("DEBUGGER.txt", true))
            {
                Logger.WriteLine("#> " + " Application stopped !---|| " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff"));
                Logger.WriteLine(" ");
            }
            Console.Clear();
            Console.WriteLine("    ");
            Console.WriteLine("    ");
            Console.WriteLine("                                      THANK YOU FOR USING OUR SYSTEM, BYE! :) ");  //LAST DISPLAY BEFORE THE SYSTEM APPLICATION SHUTS DOWN
            Console.ReadKey();
        }
    }
}
