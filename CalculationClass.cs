using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBILL
{
    internal class CalculationClass 
    {
       public  static (double, double) UserDomestic(double KLUsed)       //Calculate Amount OF water used for Business user type
        {
            double UserPortable = 0;
            double UserWaste = 0;

            if (KLUsed >= 0 && KLUsed <= 5)                       // Calculate PORTABLE WATER USED FOR BUSINESS CUSTOMER TYPE
            {
                UserPortable = KLUsed * 3.60;
                UserWaste = KLUsed * 0.65;
            }

            else if (KLUsed >= 6 && KLUsed <= 15)
            {
                UserPortable = (5 * 3.60) + ((KLUsed - 5) * 11.78);
                UserWaste = (5 * 0.65) + ((KLUsed - 5) * 2.95);
            }

            else if (KLUsed >= 16 && KLUsed <= 25)
            {
                UserPortable = (5 * 3.60) + (10 * 11.78) + ((KLUsed - 15) * 20.62);
                UserWaste = (5 * 0.65) + (10 * 2.95) + ((KLUsed - 15) * 4.41);
            }


            else if (KLUsed >= 26 && KLUsed <= 40)
            {
                UserPortable = (5 * 3.60) + (10 * 11.78) + (10 * 20.62) + ((KLUsed - 24) * 31.72);
                UserWaste = (5 * 0.65) + (10 * 2.95) + (10 * 4.41) + ((KLUsed - 24) * 5.89);
            }

            else if (KLUsed > 41)
            {
                UserPortable = (5 * 3.60) + (10 * 11.78) + (10 * 20.62) + (15 * 31.72) + ((KLUsed - 40) * 39.66);
                UserWaste = (5 * 0.65) + (10 * 2.95) + (10 * 4.41) + (15 * 5.89) + ((KLUsed - 40) * 7.36);
            }

            else
                Console.WriteLine("                 -------------------INVALID INPUT!-------------------                       ");

            return (UserPortable, UserWaste);
        }
        //----------------------------------------------------------------------------------------------------
        public static (double, double) UserBusiness(double KLUsed)   //Calculate Amount OF water used for Business user type
        {
            double UserPortable = 0;
            double UserWaste = 0;

            if (KLUsed >= 0 && KLUsed <= 5)         // Calculate PORTABLE WATER USED FOR BUSINESS CUSTOMER TYPE
            {
                UserPortable = KLUsed * 4.32;
                UserWaste = KLUsed * 0.65;

            }

            else if (KLUsed >= 6 && KLUsed <= 15)
            {
                UserPortable = (5 * 4.32) + ((KLUsed - 5) * 12.82);
                UserWaste = (5 * 0.65) + ((KLUsed - 5) * 2.95);
            }

            else if (KLUsed >= 16 && KLUsed <= 25)
            {
                UserPortable = (5 * 4.32) + (10 * 12.82) + ((KLUsed - 15) * 22.44);
                UserWaste = (5 * 0.65) + (10 * 2.95) + ((KLUsed - 15) * 4.41);

            }

            else if (KLUsed >= 26 && KLUsed <= 40)
            {
                UserPortable = (5 * 4.32) + (10 * 12.82) + (10 * 22.44) + ((KLUsed - 24) * 34.52);
                UserWaste = (5 * 0.65) + (10 * 2.95) + (10 * 4.41) + ((KLUsed - 24) * 5.89);

            }

            else if (KLUsed > 41)
            {
                UserPortable = (5 * 4.32) + (10 * 12.82) + (10 * 22.44) + (15 * 34.52) + ((KLUsed - 40) * 43.16);
                UserWaste = (5 * 0.65) + (10 * 2.95) + (10 * 4.41) + (15 * 5.89) + ((KLUsed - 40) * 7.36);
            }

            else
                Console.WriteLine("                 -------------------INVALID INPUT!-------------------                       ");

            return (UserPortable, UserWaste);
        }

        //Calculate the VAT from total amount
        public static double Get_VAT(double KLamount, double Portable, double Wwaste, string usertype)
        {
            double TotalAmount = Portable + Wwaste;

            double AddVAT;
            double vatRate = 0.14;

            if (KLamount <= 5)
                AddVAT = 0;

            else if (usertype == "Domestic")
                AddVAT = vatRate * TotalAmount - (((5 * 3.6) * vatRate) + ((5 * 0.65) * vatRate));  //Calculate overall amount of VAT and deduct VAT for 5 kiloliters for both Portable and Waste water

            else if (usertype == "Business")
                AddVAT = vatRate * TotalAmount - (((5 * 4.32) * vatRate) + ((5 * 0.65) * vatRate));
            else
            {
                Console.WriteLine("           ---------------------INVALID INPUT!--------------------------          ");
                AddVAT = 0;
            }
            return AddVAT;
        }

    }
}
