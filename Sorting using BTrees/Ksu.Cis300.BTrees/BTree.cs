/* BTree.cs
 * Author: Zachery Brunner
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.BTrees
{
    class BTree<TKey, TValue>: ITree
        where TKey: IComparable<TKey>
    {
        /// <summary>
        /// the minimum degree of the tree. This is also the 
        /// minimum number of children for nodes in the tree
        /// </summary>
        private int _size;

        /// <summary>
        /// the maximum number of children for the nodes in the tree. 
        /// This should be equal to _size * 2.
        /// </summary>
        private int _maxChildren;

        /// <summary>
        ///  the minimum number of keys for each node in the tree, excluding the root. 
        ///  This should be equal to _size – 1.
        /// </summary>
        private int _minKeys;

        /// <summary>
        ///  the maximum number of keys for each node in the tree. 
        ///  This should be equal to _size * 2 – 1.
        /// </summary>
        private int _maxKeys;

        /// <summary>
        /// The root node of the tree
        /// </summary>
        private BTreeNode<TKey, TValue> _root;

        /// <summary>
        /// Returns if the root is null
        /// </summary>
        public bool IsEmpty
        {
            get { return (_root == null); }
        }   //END OF IsEmpty

        /// <summary>
        /// Returns the children of the root node
        /// Will need to cast to an ITree[]
        /// </summary>
        public ITree[] Children
        {
            get { return _root.Children; }
        }   //END OF Children

        /// <summary>
        /// Returns the root of the ndoe
        /// </summary>
        public object Root
        {
            get { return _root; }
        }   //END OF Root

        /// <summary>
        /// Public constructor that initializes all of the corresponding private fields 
        /// </summary>
        /// <param name="size">Size used to help with initializations</param>
        public BTree(int size)
        {
            if(size < 2)
            {
                throw new InvalidOperationException("Degree cannot be less than 2");
            }   //END OF IF STATEMENT
            _size = size;
            _maxChildren = _size * 2;
            _minKeys = _size - 1;
            _maxKeys = (_size * 2) - 1;
            _root = new BTreeNode<TKey, TValue>(_minKeys, _maxKeys, _maxChildren, true);
        }   //END OF BTree Constructor

        /// <summary>
        /// Method that inserts a node into the B-Tree starting at the root node
        /// </summary>
        /// <param name="key">Generic Key used to add</param>
        /// <param name="value">Generic Value used to add</param>
        public void Insert(TKey key, TValue value)
        {
            if(_root.IsEmpty)
            {
                _root.AddItem(key, value);
            }   //END OF IF STATEMENT
            else
            {
                if(_maxKeys == _root.KeyCount)
                {
                    BTreeNode<TKey, TValue> newRoot = new BTreeNode<TKey, TValue>(_minKeys, _maxKeys, _maxChildren, false);
                    newRoot.AddChild(0, _root);
                    newRoot.SplitChild(0);
                    newRoot.InsertNonFull(key, value);
                    _root = newRoot;                   
                }   //END OF IF STATEMENT
                else
                {
                    _root.InsertNonFull(key, value);
                }   //END OF ELSE STATEMENT
            }   //END OF ELSE STATEMENT
        }   //END OF Insert METHOD

        /// <summary>
        /// Just a helper function that calls Find on the root node
        /// </summary>
        /// <param name="key">The key we are trying to find</param>
        /// <returns>The value if any that is associated with that key</returns>
        public TValue Find(TKey key)
        {
            return _root.Find(key);
        }   //END OF Find
    }   //END OF CLASS
}   //END OF PROGRAM