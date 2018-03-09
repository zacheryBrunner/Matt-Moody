using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.ConnectFour
{
    class DoubleLinkedListCell<T>
    {
        //The pointer to the next cell in the linked list
        private DoubleLinkedListCell<T> _next = null;
        //The pointer to the previous cell in the linked list
        private DoubleLinkedListCell<T> _prev = null;
        //The generic field for storing information in this cell
        private T _data = default;
        //The unique identifier for the cell
        private string _id;

        /// <summary>
        /// Gets and Sets the previous cell in the LinkedList
        /// </summary>
        public DoubleLinkedListCell<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }   //END OF Next

        /// <summary>
        /// Gets and Sets the previous cell in the LinkedList
        /// </summary>
        public DoubleLinkedListCell<T> Prev
        {
            get { return _prev; }
            set { _prev = value; }
        }   //END OF Prev

        /// <summary>
        /// Gets and sets the Data contains in each Cell in the LinkedList
        /// </summary>
        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }   //END OF Data

        /// <summary>
        /// Gets and Sets the ID for each Cell in the LinkedList
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }   //END OF Id

        /// <summary>
        /// Initializes the LinkedListCell with a unique identifier
        /// </summary>
        /// <param name="identifier">Contains the unique identifier</param>
        public DoubleLinkedListCell(string identifier)
        {
            _id = identifier;
        }   //END OF DoubleLinkedListCell
    }   //END OF CLASS
}   //END OF PROGRAM
