/************************
 * Author: Zachery Brunner
 * Class: ReceiptManager.cs
 * Date: 2/9/18
 * ***********************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales501
{
    /// <summary>
    /// This class is called whenever the user is creating, adjusting, creating a rebate 
    /// or generating rebates for any receipt
    /// </summary>
    static class ReceiptManager
    {
        /// <summary>
        /// Private dictonary used to hold all of the receipts inputed into the program
        /// </summary>
        private static Dictionary<string, Receipt> _receiptList = new Dictionary<string, Receipt>();

        /// <summary>
        /// Private List used to hold all of the rebates that need to be generated
        /// </summary>
        private static Dictionary<string, Receipt> _rebateList = new Dictionary<string, Receipt>();

        /// <summary>
        /// Private int to keep track of the number of transactions
        /// </summary>
        private static int _transactionNumber = 1;
        
        /// <summary>
        /// Used to print a receipt to the console
        /// </summary>
        /// <param name="receiptName">Used to identity the receipt needing to be printed</param>
        /// <returns>A string representation of the receipt</returns>
        private static string PrintReceipt(string receiptName)
        {
            if (_receiptList.ContainsKey(receiptName))
            {
                return _receiptList[receiptName].ToString();
            }   //END OF IF STATEMENT
            return "The receipt asked for does not exist\n";
        }   //END OF PrintReceipt METHOD

        /// <summary>
        /// Used to create new receipts
        /// </summary>
        public static void CreateNewReceipt()
        {
            string[] date;
            int[] monthAndDay = new int[2];
            Console.Write("Enter the date in the form (MM/DD): ");

            //This Do-While loop makes sure the user inputs a valid date
            do
            {
                date = Console.ReadLine().Split('/');
                try
                {
                    monthAndDay[0] = Convert.ToInt32(date[0]);
                    monthAndDay[1] = Convert.ToInt32(date[1]);
                    if(monthAndDay[0] <=0 || monthAndDay[0] >= 13 ||monthAndDay[1] > 31 || monthAndDay[1] <= 0)
                    {
                        Console.Write("Please enter a valid date in the format (MM/DD): ");
                    }
                } catch(Exception)
                {
                    Console.Write("Not a date...... \n\nPlease enter a date in the format (MM/DD): ");
                }
            } while (date.Length != 2 || monthAndDay[0] <= 0 || monthAndDay[0] >= 13 || monthAndDay[1] > 31 || monthAndDay[1] <= 0);

            Receipt r = new Receipt(_transactionNumber.ToString(), monthAndDay[0], monthAndDay[1]);
            _receiptList.Add(_transactionNumber.ToString(), r);
            r.Add();
            Console.WriteLine(PrintReceipt(_transactionNumber.ToString()));
            _transactionNumber++;
        }   //END OF CreateNewReceipt METHOD

        /// <summary>
        /// This method is used to Identify a receipt and check to see if a rebate is made,
        /// If it has not then will precede to remove item if it exist 
        /// </summary>
        public static void RemoveItemFromReceipt()
        {
            Console.Write("What receipt would you like to return an item from? ");
            string receiptName = Console.ReadLine().Trim();
            if (_receiptList.ContainsKey(receiptName))
            {
                if (!_receiptList[receiptName].RebateCreated)
                {
                    Console.Write("What item would you like to remove? ");
                    _receiptList[receiptName].Remove(Console.ReadLine().Trim());
                }   //END OF IF STATEMENT
                else
                {
                    Console.Write("You have already sent this check in for a rebate...... Cannot return item");
                }   //END OF ELSE STATEMENT
            }   //END OF IF STATEMENT
            else
            {
                Console.WriteLine("Receipt could not be found");
            }   //END OF IF STATEMENT
        }   //END OF RemoveItemFromReceipt METHOD

        /// <summary>
        /// This method begins the process for creating a rebate
        /// </summary>
        public static void createRebate()
        {
            Console.WriteLine("What receipt would you like to create a rebate for? ");
            string receiptName = Console.ReadLine();
            if (_receiptList.ContainsKey(receiptName))
            {
                if(_receiptList[receiptName].Month < 6 || _receiptList[receiptName].Month > 6)
                {
                    Console.WriteLine("Purchase was not made in the month of June, cannot create rebate");
                    return;
                }
                else if (!_receiptList[receiptName].RebateCreated)
                {
                    _rebateList.Add(Rebate.getInformation(_receiptList[receiptName]), _receiptList[receiptName]);
                }
                else
                {
                    Console.WriteLine("Rebate could not be made beacuse a rebate has already been made");
                }
            }
            else
            {
                Console.WriteLine("Receipt does not exist");
            }
        }   //END OF createRebate METHOD

        /// <summary>
        /// This method is used to generate rebates for everything in the _rebate dictionary
        /// </summary>
        public static void generateRebates()
        {
            StringBuilder sb = new StringBuilder();
            foreach(string s in _rebateList.Keys)
            {
                if (_rebateList[s].RebateGenerated == true)
                {
                    Receipt receipt = _rebateList[s];
                    _receiptList[receipt.ReceiptNumber].RebateCreated = true;
                    sb.Append(s);
                    sb.Append("\t\tRebate: " + decimal.Round((decimal)(receipt.Total * .11), 2).ToString() + "\n------------------------------------------------------------\n");
                    Console.WriteLine(sb.ToString());
                    sb.Clear();
                }
            }
            _rebateList.Clear();
        }   //END OF generateRebates METHOD
    }   //END OF STATIC CLASS
}   //END OF PROGRAM