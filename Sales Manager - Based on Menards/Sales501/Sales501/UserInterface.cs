/****************
 * Author: Zachery Brunner
 * Class: UserINterface.cs
 * Date: 2/9/18
 * ********************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales501
{
    /// <summary>
    /// Used to run the program
    /// </summary>
    class UserInterface
    {
        /// <summary>
        /// Used to run the program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("1 = Make a receipt, 2 = Return and item, 3 = Create a rebate, 4 = Generate Rebates, 5 = Quit: ");
                string answer = Console.ReadLine().ToUpper();
                switch (answer)
                {
                    case "1":
                        ReceiptManager.CreateNewReceipt();
                        break;

                    case "2":
                        ReceiptManager.RemoveItemFromReceipt();
                        break;

                    case "3":
                        ReceiptManager.createRebate();
                        break;

                    case "4":
                        ReceiptManager.generateRebates();
                        break;

                    case "5":
                        System.Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid input!!");
                        break;
                }   //END OF SWITCH CASE
            }   //END OF WHILE LOOP (WHILE LOOP ALWAYS RUNS)
        }   //END OF MAIN METHOD
    }   //END OF CLASS
}   //END OF PROGRAM