using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBILL
{
    public  class Method_Ex
    {
        public string FirstName;   // INSTANCE VARIABLES
        public string Lastname;
        public string Location;
        public string UserType;
        public string UserName;
        public string UserPassword;
        public string PlotNumber;
        public double WAterUsed;

        public Method_Ex()              //ConstructorS
        {
            FirstName = " ";
            Lastname = " ";
            PlotNumber = " ";
            Location = " ";
            UserType = " ";
            WAterUsed = 0;
            UserName = " ";
            UserPassword = " ";
        }

        public static string Logins() // First Login Display
        {
            string FirstInput;
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("                      Welcome to Water Utilities System :)  ");
            Console.WriteLine("                    -Choose Corresponding number To proceed-");
            Console.WriteLine("                         1) Existing Customer");
            Console.WriteLine("                         2) New Customer (Create Account) ");
            Console.Write("                                         ->");
            FirstInput = Console.ReadLine();
            Console.Clear();

            while (FirstInput != "1" && FirstInput != "2")
            {
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine("                      Welcome to Water Utilities System :)  ");
                Console.WriteLine("                    -Choose Corresponding number To proceed-");
                Console.WriteLine("                         1) Existing Customer");
                Console.WriteLine("                         2) New Customer (Create Account) ");
                Console.WriteLine("                     >>>>>>>Invalid Input, TRY AGAIN.<<<<<<<<<");
                Console.Write("                                           ->");
                FirstInput = Console.ReadLine();
                Console.Clear();
            }
            Console.Clear();
            return FirstInput;
        }
        //********************************************************************************************************************************
        public static (string, string, string, string, string, string, string) SIGNUP_Customer()

        {
            string type = " ", First_name = " ", Last_name = " ", Plot_number = " ", Location = " ", UserName = " ", Password = " ";

            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("                         Fill in the below details");
            Console.WriteLine("      ");
            Console.WriteLine("                    Press 1 0r 2 to choose type of user -> ");
            Console.WriteLine("                         ");
            Console.WriteLine("               1) Domestic User                 2)Business ");
            Console.Write("                                   -> ");

            int typeChoise = Convert.ToInt32(Console.ReadLine());
            if (typeChoise == 1)       //CONVERT THE USER TYPE INPUT TO AN UNDERSTANDERBLE STRING VALUE
                type = "Domestic";

            else if (typeChoise == 2)
                type = "Business";
            else
                Console.WriteLine("                       INVALID INPIT         ");

            Console.Clear();

            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("                         Fill in the below details");
            Console.Write("                           Firstname -> ");
            First_name = Console.ReadLine();
            Console.Write("                            Lastname -> ");
            Last_name = Console.ReadLine();
            Console.Write("                         Plot Number -> ");
            Plot_number = Console.ReadLine();
            Console.Write("                            Location -> ");
            Location = Console.ReadLine();


            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("                         ACCOUNT USERNAME & PASSWORD SETUP");
            Console.Write("                    Account Username -> ");
            UserName = Console.ReadLine();
            Console.Write("                       User Password -> ");
            Password = Console.ReadLine();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("        >>>>>>>>Sign-up Succsessful!!  Click Enter To begin Login<<<<<<<<<<  ");
            Console.ReadKey();
            Console.Clear();

            using (StreamWriter Logger = new StreamWriter("DEBUGGER.txt", true))
            {
                Logger.WriteLine("#> " + First_name + " " + Last_name + " created an account!---|| " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff"));
                Logger.WriteLine(" ");
            }

            return (type, First_name, Last_name, Plot_number, Location, UserName, Password);
        }       
        //******************************************************************************************************************************
        public static void Get_bill(string FirstName2, string lastNmae, string location, string PLot, string userType)
        {
            double Portable_Total;
            double Waste_Total;                          //DECLARE OUR VARIBLES
            double WaterUsed = -2;
            using (StreamWriter Logger = new StreamWriter("DEBUGGER.txt", true))
            {
                Logger.WriteLine("#> " + FirstName2 + " " + lastNmae + " Successfully logged into account!---|| " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff"));
                Logger.WriteLine(" ");
            }

            do
            {
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine("                                   || " + FirstName2.ToUpper() + " " + lastNmae.ToUpper() + " ||");
                Console.WriteLine("                         ");
                Console.WriteLine("                           Enter Amount of water used (Kl) Below ");                         //GET AMOUNT USED BY THE CUSTOMER
                Console.Write("                                        -> ");
                WaterUsed = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
            } while (WaterUsed <= -1);

            var DomesticPortableWasteAmount = CalculationClass.UserDomestic(WaterUsed);
            var BusinessPortableWasteAmount = CalculationClass.UserBusiness(WaterUsed);

            if (userType == "Domestic")// DISPLAY BILL FOR DOMESTIC USER ACCOUNTS
            {
                Portable_Total = DomesticPortableWasteAmount.Item1;
                Waste_Total = DomesticPortableWasteAmount.Item2;
                Get_Bill(FirstName2, lastNmae, PLot, userType, location, WaterUsed, Portable_Total, Waste_Total);
            }

            else if (userType == "Business")  // DISPLAY BILL FOR BUSINESS ACCOUNTS To consle
            {

                Portable_Total = BusinessPortableWasteAmount.Item1;
                Waste_Total = BusinessPortableWasteAmount.Item2;
                Get_Bill(FirstName2, lastNmae, PLot, userType, location, WaterUsed, Portable_Total, Waste_Total);
            }
        }
        //***************************************************************************************************************************^^^^^^^^

        static void Get_Bill(string Fnanme, string Lname, string plot, string type, string Location, double used, double portable, double waste)
        {
            double VAT1;
            double totals;
            string currentTime = System.DateTime.Now.ToShortDateString();                         //Output FINAL BILL INFORMATION TO THE CONSOLE APPLICATION

            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("    Name: " + Fnanme + " " + Lname + "           Plot: " + plot + "            Monthly Bill");
            Console.WriteLine("                         ");
            Console.WriteLine("                               User Type: " + type);
            Console.WriteLine("                               Location: " + Location);
            Console.WriteLine("                Potable Water Used (Kl): BWP" + used);

            Console.WriteLine("                     Potable Water Cost: BWP" + portable.ToString("#.##"));
            Console.WriteLine("                       Waste Water Used: BWP" + waste.ToString("#.##"));
            Console.WriteLine(" ");

            VAT1 = CalculationClass.Get_VAT(used, portable, waste, type);
            Console.WriteLine("                                    VAT: BWP" + VAT1.ToString("#.##"));
            Console.WriteLine("     ");
            totals = waste + portable + VAT1;
            Console.WriteLine("                           Total Amount: BWP" + totals.ToString("#.##"));
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------------------");

            //============================================================ PRINT INFORMATION TO TEXT FILE
            StreamWriter Text_Print;
            Text_Print = new("MyOUTPUT.txt");
            Text_Print.WriteLine("----------------------------------------------------------------------------------");
            Text_Print.WriteLine("        Name: " + Fnanme + " " + Lname + "      Plot: " + plot + "        Monthly Bill");
            Text_Print.WriteLine("                         ");
            Text_Print.WriteLine("                               User Type: " + type);
            Text_Print.WriteLine("                               Location: " + Location);
            Text_Print.WriteLine("                Potable Water Used (Kl): BWP" + used);
            Text_Print.WriteLine("                     Potable Water Cost: BWP" + portable.ToString("#.##"));
            Text_Print.WriteLine("                       Waste Water Used: BWP" + waste.ToString("#.##"));
            Text_Print.WriteLine(" ");
            Text_Print.WriteLine("                                    VAT: BWP" + VAT1.ToString("#.##"));
            Text_Print.WriteLine("      ");
            Text_Print.WriteLine("                           Total Amount: BWP" + totals.ToString("#.##"));
            Text_Print.WriteLine("      ");
            Text_Print.WriteLine("Date Printed : " + currentTime);
            Text_Print.WriteLine("----------------------------------------------------------------------------------");
            Text_Print.WriteLine("----------------------------------------------------------------------------------");
            Text_Print.Close();
            Console.WriteLine("                    ===========   TEXT PRINT SUCCESSFULL!   =========");
        }
    }
}
