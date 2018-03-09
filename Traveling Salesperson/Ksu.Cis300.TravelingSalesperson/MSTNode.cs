/*
 * Author: Zachery Brunner
 * Class: MSTNode.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.TravelingSalesperson
{
    class MSTNode : ITree
    {
        /// <summary>
        /// The weight of the graph edge that took us to this node
        /// </summary>
        private int _data;

        /// <summary>
        /// The array index from the adjacency matrix of the parent node
        /// </summary>
        private int _parent;

        /// <summary>
        /// The string representation of the node
        /// </summary>
        private string _label;

        /// <summary>
        /// The children of this node
        /// </summary>
        private List<MSTNode> _children = new List<MSTNode>();

        /// <summary>
        /// Getter and Setter for the _data field
        /// </summary>
        public int Data
        {
            set { _data = value; }
            get { return _data; }
        }   //END OF Data

        /// <summary>
        /// Getter and Setter for the _parent field
        /// </summary>
        public int Parent
        {
            set { _parent = value; }
            get { return _parent; }
        }   //END OF Parent

        /// <summary>
        /// Returns a string that has the label of the node combinded with the data in the paretheses
        /// </summary>
        public object Root
        {
            get { return (_label + " (" + _data + ")").ToString(); }
        }   //END OF Root

        ITree[] ITree.Children
        {
            get { return _children.ToArray(); }
        }   //END OF ITree.Children

        /// <summary>
        /// Getter to return whether the node is empty
        /// </summary>
        public bool IsEmpty
        {
            get { return false; }
        }   //END OF IsEmpty

        /// <summary>
        /// Public constructor for the MSTNode
        /// </summary>
        /// <param name="data">Used to initialize _data</param>
        /// <param name="parent">Used to initialize _parent</param>
        /// <param name="label">Used to initialize _label</param>
        public MSTNode(int data, int parent, string label)
        {
            _label = label;
            _data = data;
            _parent = parent;
        }   //END OF MSTNode CONSTRUCTOR

        /// <summary>
        /// Adds the given child to the _children list
        /// </summary>
        /// <param name="child">The child that needs to be added to the list</param>
        public void AddChild(MSTNode child)
        {
            _children.Add(child);
        }   //END OF AddChild

        /// <summary>
        /// Recusive helper function to complete the walk or tour
        /// </summary>
        /// <param name="sb">String builder that will be passed back holding the entire tour</param>
        private void Walk(StringBuilder sb)
        {
            sb.Append(" to " + _label + Environment.NewLine + _label);            
            foreach(MSTNode child in _children)
            {
               child.Walk(sb);
            }   //END OF FOR LOOP
        }   //END OF OverLoadeed Walk METHOD

        /// <summary>
        /// Initiates the pre-order depth-first tour
        /// </summary>
        /// <returns>The full tour in a string form</returns>
        public string Walk()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_label);
            foreach(MSTNode child in _children)
            {
                child.Walk(sb);
            }   //END OF FOR LOOP
            return sb.Append(" to " + _label).ToString();
        }   //END OF Walk METHOD
    }   //END OF CLASS
}   //END OF PROGRAM