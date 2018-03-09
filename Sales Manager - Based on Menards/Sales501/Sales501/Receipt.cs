/****************
 * Author: Zachery Brunner
 * Class: Receipt.cs
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
    /// This class is used to create receipts
    /// </summary>
    class Receipt
    {
        /// <summary>
        /// String variable used to hold the ReceiptNumber
        /// </summary>
        private string _receiptName;

        /// <summary>
        /// List variable used to hold the items on the list
        /// </summary>
        private Dictionary<string, Item> _ItemList;

        /// <summary>
        /// Private variable used to hold the total amount of the items on the receipt
        /// </summary>
        private double _total;

        /// <summary>
        /// Used to initalize the date of the reciept
        /// </summary>
        private int _month, _day;

        /// <summary>
        /// Private variable used to check and see if a rebate has been made for the check
        /// </summary>
        private bool _rebateCreate = false;

        /// <summary>
        /// Private variable used to see if a rebate has been generated
        /// </summary>
        private bool _rebateGenerated = false;

        /// <summary>
        /// Getter for the _month variable
        /// </summary>
        public int Month
        {
            get { return _month; }
        }   //END OF Month

        /// <summary>
        /// Getter for the _day variable
        /// </summary>
        public int Day
        {
            get { return _day; }
        }   //END OF Day

        /// <summary>
        /// Getter for the _receiptNumber variable
        /// </summary>
        public string ReceiptNumber
        {
            get { return _receiptName; }
        }   //END OF ReceiptNumber

        /// <summary>
        /// Getter for the _total variable
        /// </summary>
        public double Total
        {
            get { return _total; }
        }   //END OF Total

        /// <summary>
        /// Getter and setter for the _rebateCreated variable
        /// </summary>
        public bool RebateCreated
        {
            get { return _rebateCreate; }
            set { _rebateCreate = value; }
        }   //END OF RebateMade

        /// <summary>
        /// Getter and setter for the _rebateGenerated variable
        /// </summary>
        public bool RebateGenerated
        {
            get { return _rebateGenerated; }
            set { _rebateGenerated = value; }
        }   //END OF RebateGenerated
        
        /// <summary>
        /// Public constructor for the Receipt object
        /// </summary>
        /// <param name="number">Transaction number</param>
        /// <param name="month">Month the transaction took place</param>
        /// <param name="day">Day the transaction took place</param>
        public Receipt(string number, int month, int day)
        {
            _receiptName = number;
            _ItemList = new Dictionary<string, Item>();
            _month = month;
            _day = day;
        }   //END OF Receipt CONSTRUCTOR

        /// <summary>
        /// Used to add items to the reciept
        /// </summary>
        public void Add()
        {
            string answer = " ";
            //This Do-While will create Items until the user tells them they are done
            do
            {
                string name = "";
                int quantity = 0;
                double price = -1;
                Console.Write("Enter the name of the item: ");
                name = Console.ReadLine();

                //This While loop makes sure that the user is nice to the program by making them enter an integer value for the quantity variable
                while (quantity <= 0)
                {
                    Console.Write("Enter the quantity of the item: ");
                    try
                    {
                        quantity = Convert.ToInt32(Console.ReadLine());
                        if (quantity <= 0)
                        {
                            Console.WriteLine("Invalid Quantity...... Quantity must be positive");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid quantity...... Quantity must be a whole number");
                    }
                }   //END OF WHILE LOOP

                //This While loop makes sure that the user is nice to the program by making them enter a double for the price variable
                while (price < 0)
                {
                    Console.Write("Enter the price of the item: ");
                    try
                    {
                        price = Convert.ToDouble(Console.ReadLine());
                        if (price < 0)
                        {
                            Console.WriteLine("Invalid price...... Price must be at least zero");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid price..... Price must be a number");
                    }
                }

                //If-Else block to check if the item already has been inputed into the receipt
                //If so it will ignore the inputted price and just add to the quantity
                if (!_ItemList.ContainsKey(name))
                {
                    _ItemList.Add(name, new Item(name, price, quantity));
                }   //END OF IF STATEMENT
                else
                {
                    _ItemList[name].Quantity += quantity;
                    Console.WriteLine("Price ignored, Quantity added to original item");
                }   //END OF ELSE STATEMENT

                Console.Write("Would you like to enter another item? (Y)es or (N)o: ");
                answer = (Console.ReadLine().ToUpper());

                //This while loop makes sure the user enters a valid argument to continue the program
                while (answer[0] != 'Y' && answer[0] != 'N')
                {
                    if (answer[0] != 'Y' && answer[0] != 'N')
                    {
                        Console.WriteLine("Please enter (Y)es or (N)o: ");
                        answer = Console.ReadLine().ToUpper();
                    }   //END OF IF STATEMENT
                }   //END OF WHILE LOOP

            } while ('Y' == answer[0]);
            calculateTotal();
        }   //END OF Add METHOD

        /// <summary>
        /// Private method used to calculate the total of the receipt
        /// </summary>
        private void calculateTotal()
        {
            double total = 0;
            List<Item> ItemList = _ItemList.Values.ToList();
            foreach(Item item in ItemList)
            {
                total += (item.Quantity * item.Cost);
            }   //END OF FOREACH LOOP
            _total = total;
        }   //END OF calculateTotal METHOD

        /// <summary>
        /// Method used to remove an item from the list
        /// </summary>
        /// <param name="name">Used to identity the item needing to be removed</param>
        public void Remove(string name)
        {
            if (_ItemList.ContainsKey(name))
            {
                int remove = -1;
                while (remove < 0 || _ItemList[name].Quantity < remove)
                {
                    Console.Write("How many would you like to remove? ");
                    try
                    {
                        remove = Convert.ToInt32(Console.ReadLine());
                        if (_ItemList[name].Quantity < remove)
                        {
                            Console.WriteLine("You do not have that many to return: ");
                        }
                        else if(_ItemList[name].Quantity < 0)
                        {
                            Console.WriteLine("Return value cannot be negative");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("That is not a whole number......");
                    }
                }   //END OF WHILE LOOP

                _ItemList[name].Quantity -= remove;

                if(_ItemList[name].Quantity == 0)
                {
                    _ItemList.Remove(name);
                    Console.WriteLine("Item was removed from list");
                }
                else
                {
                    Console.WriteLine("{0} {1}'s were returned for the {2} transaction", remove, name, _receiptName);
                }
                calculateTotal();
            }   //END OF IF STATEMENT
            else
            {
                Console.WriteLine("Item was not found in the list");
            }   //END OF ELSE STATEMENT
        }   //END OF Remove METHOD

        /// <summary>
        /// Used to make a string representation of the receipt
        /// </summary>
        /// <returns>A string representation of the receipt</returns>
        public override string ToString()
        {
            List<Item> ItemList = _ItemList.Values.ToList();
            StringBuilder sb = new StringBuilder();
            sb.Append("------------------------------------------------------------\nSales 501 Hardware\nReceipt Name: " + _receiptName + "\tDate: " + _month + "/" + _day + "\n");
            foreach(Item item in ItemList)
            {
                sb.Append(item.ToString() + "\n");
            }   //END OF FOREACH LOOP
            sb.Append("\n\t\tTotal: $" + _total.ToString() + "\n------------------------------------------------------------\n");
            return sb.ToString();
        }   //END OF override ToString METHOD
    }   //END OF CLASS
}   //END OF PROGRAM