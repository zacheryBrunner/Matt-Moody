/**********************
 * Author: Zachery Brunner
 * Class: Rebate.cs
 * Date: 2/10/18
 * ********************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales501
{
    /// <summary>
    /// Used to help make rebates for the program
    /// </summary>
    static class Rebate
    {
        /// <summary>
        /// This method is used to retrieve the inormation so that it can be put on a rebate slip
        /// </summary>
        /// <param name="receipt">The receipt the program is making the rebate for</param>
        /// <returns>A string containing the rebate information</returns>
        public static string getInformation(Receipt receipt)
        {
            int day = -1;
            int month = -1;
            string[] date = null;
            do
            {
                Console.WriteLine("What day did you mail? (MM/DD): ");
                try
                {
                    date = Console.ReadLine().Split('/');
                    day = Convert.ToInt32(date[1]);
                    month = Convert.ToInt32(date[0]);
                    if ((day < 1 || day > 31) && (month < 1 || month > 12))
                    {
                        Console.WriteLine("Invalid date");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a date in the form(MM/DD)");
                }
            } while (date.Length != 2 || (day < 1 || day > 31) || (month < 1 || month > 12));
            if (month < 6 || month > 7 || (month == 7 && day > 15))
            {
                Console.WriteLine("Promotion has ended, cannot create rebate");
                return "";
            }
            else if (receipt.Month > month || (receipt.Month == month && receipt.Day > day))
            {
                Console.WriteLine("Rebate cannot be generated, you cannot mail the rebate before you made the purchase");
                return "";
            }
            else
            {
                receipt.RebateGenerated = true;
                string[] information = new string[6];
                Console.WriteLine("Enter your last name: ");
                information[0] = Console.ReadLine();
                Console.WriteLine("Enter your first name: ");
                information[1] = Console.ReadLine();
                Console.WriteLine("Enter your mailing address: ");
                information[2] = Console.ReadLine();
                Console.WriteLine("Enter your city: ");
                information[3] = Console.ReadLine();
                Console.WriteLine("Enter your state: ");
                information[4] = Console.ReadLine();
                Console.WriteLine("Enter your zipcode: ");
                information[5] = Console.ReadLine();
                return createRebate(information);
            }
        }   //END OF getInformation METHOD

        /// <summary>
        /// Used to print a rebate for the receipt that was sent in
        /// </summary>
        /// <param name="information">Used to create the string with the rebate information</param>
        /// <returns>A string containing the information of the rebate</returns>
        private static string createRebate(string[] information)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("------------------------------------------------------------\nSales 501 Hardware\nRebate: " + information[1] + " " + information[0] + "\n");
            sb.Append(information[2] + " " + information[3] + "\n");
            sb.Append(information[4] + " " + information[5] + "\n");
            return sb.ToString();
        }   //END OF printRebate
    }   //END OF CLASS
}   //END OF PROGRAM
