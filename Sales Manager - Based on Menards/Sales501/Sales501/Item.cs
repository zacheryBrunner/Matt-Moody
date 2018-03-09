/*********
 * Author: Zachery Brunner
 * Class: Item.cs
 * Date: 2/9/18
 * ****************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales501
{
    /// <summary>
    /// This class is used to create items for the program
    /// </summary>
    class Item
    {
        /// <summary>
        /// String variable used to hold the name of the "Item"
        /// </summary>
        private string _name;

        /// <summary>
        /// Double variable used to hold the cost of the "Item"
        /// </summary>
        private double _cost;

        /// <summary>
        /// Int variable used to hold the quantity of the "Item"
        /// </summary>
        private int _quantity;
        
        /// <summary>
        /// Getter for name variable
        /// </summary>
        public string Name
        {
            get { return _name; }
        }   //END OF Name

        /// <summary>
        /// Getter for the cost variable
        /// </summary>
        public double Cost
        {
            get { return _cost; }
        }   //END OF Cost

        /// <summary>
        /// Getter for the quantity variable
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }   //END OF Quantity

        /// <summary>
        /// Public constructor used to create an Item object
        /// </summary>
        /// <param name="itemName">Name of the Item used to initialize the name</param>
        /// <param name="itemCost">The price of the item used to initialize the cost field</param>
        /// <param name="quan">The number of the item being bought used to initalize the quantity field</param>
        public Item(string itemName, double itemCost, int quan)
        {
            _name = itemName;
            _cost = itemCost;
            _quantity = quan;
        }   //END OF Item Constructor

        /// <summary>
        /// Used to make a string containing all the information on the item
        /// </summary>
        /// <returns>A string representation of the item</returns>
        public override string ToString()
        {
            return (_name + "\t" + _quantity.ToString() + "\t" + _cost.ToString());
        }   //END OF override ToString METHOD
    }   //END OF CLASS
}   //END OF PROGRAM