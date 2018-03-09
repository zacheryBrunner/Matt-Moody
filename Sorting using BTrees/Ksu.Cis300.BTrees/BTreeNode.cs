/* BTreeNode.cs
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
    class BTreeNode<TKey, TValue> : ITree
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// keeps track of how many keys are currently in this node.
        /// This field is accessible through the public property KeyCount
        /// </summary>
        private int _keyCount = 0;

        /// <summary>
        /// Stores the minimum number of keys this node can have.
        /// </summary>
        private int _minKeyCount;

        /// <summary>
        /// An array that holds the keys of this node in ascending order
        /// </summary>
        private TKey[] _keys;

        /// <summary>
        /// keeps track of the number of children in this node.
        /// </summary>
        private int _childCount;

        /// <summary>
        /// an array that stores the pointers to the children of this node. 
        /// This field is accessible through the public property ITree[] Children
        /// </summary>
        private BTreeNode<TKey, TValue>[] _children;

        /// <summary>
        /// Stores the values of the corresponding keys from the _keys array
        /// </summary>
        private TValue[] _values;

        /// <summary>
        ///  Indicates if this node is a leaf or not. 
        ///  This field is accessible through the public property IsLeaf
        /// </summary>
        private bool _isLeaf;

        /// <summary>
        /// Getter for the _children property
        /// </summary>
        public ITree[] Children
        {
            get { return _children; }
        }   //END OF Children

        /// <summary>
        /// Getter for the _isLeaf Property
        /// </summary>
        public bool IsLeaf
        {
            get { return _isLeaf; }
        }   //END OF IsLeaf    

        /// <summary>
        /// A property that returns if the number of keys in this node is 0
        /// </summary>
        public bool IsEmpty
        {
            get { return (_keyCount == 0); }
        }   //END OF IsEmpty PROPERTY

        /// <summary>
        ///  A property that returns this
        /// </summary>
        public object Root
        {
            get { return this; }
        }   //END OF Root

        /// <summary>
        /// A property that returns _keyCount
        /// </summary>
        public int KeyCount
        {
            get { return _keyCount; }
        }   //END OF KeyCount        

        /// <summary>
        /// This is the constructor for the BtreeNode
        /// </summary>
        /// <param name="minKeyCount">Minimum number of keys that each node can have</param>
        /// <param name="maxKeyCount">Maximum number of keys</param>
        /// <param name="maxChildCount">Maximum number of children</param>
        /// <param name="leaf">Holds wheither this node should be a leaf or not</param>
        public BTreeNode(int minKeyCount, int maxKeyCount, int maxChildCount, bool leaf)
        {
            _minKeyCount = minKeyCount;
            _keys = new TKey[maxKeyCount];
            _values = new TValue[maxKeyCount];
            _children = new BTreeNode<TKey, TValue>[maxChildCount];
            _isLeaf = leaf;
        }   //END OF CONSTRUCTOR

        /// <summary>
        /// Inserts key and value in ascending order
        /// </summary>
        /// <param name="key">The key needing to be added</param>
        /// <param name="value">The value needing to be added</param>
        public void AddItem(TKey key, TValue value)
        {
            for (int i = _keyCount - 1; i >= 0; i--)
            {
                if (_keys[i].CompareTo(key) > 0)
                {
                    _keys[i + 1] = _keys[i];
                    _values[i + 1] = _values[i];
                }   //END OF IF STATEMENT
                else
                {
                    _keys[i + 1] = key;
                    _values[i + 1] = value;
                    _keyCount++;
                    return;
                }   //END OF ELSE STATEMENT
            }   //END OF FOR LOOP
            _keys[0] = key;
            _values[0] = value;
            _keyCount++;
        }   //END OF AddItem METHOD

        /// <summary>
        /// Simple helper function that stores the child in _children
        /// And incremements number of children
        /// </summary>
        /// <param name="i">The index where the child needs to be placed</param>
        /// <param name="child">The child needing to be placed</param>
        public void AddChild(int i, BTreeNode<TKey, TValue> child)
        {
            _children[i] = child;
            _childCount++;
        }   //END OF AddChild

        /// <summary>
        /// Splits a node once all spots are full
        /// </summary>
        /// <param name="index">The index at which to split the nodes</param>
        public void SplitChild(int index)
        {
            BTreeNode<TKey, TValue> newNode = new BTreeNode<TKey, TValue>(_minKeyCount, _keys.Length, _children.Length, _children[index].IsLeaf);
            BTreeNode<TKey, TValue> splitNode = _children[index];
            for (int i = 0, k = _minKeyCount + i + 1; i < _minKeyCount; i++, k++)
            {
                newNode.AddItem(splitNode._keys[k], splitNode._values[k]);
                splitNode._keys[k] = default(TKey);
                splitNode._values[k] = default(TValue);
            }   //END OF FOR LOOP
            if (!newNode.IsLeaf)
            {
                for (int j = _children.Length / 2, l = 0; j < _children.Length; j++, l++)
                {
                    if (splitNode.Children[j] != null)
                    {
                        newNode.AddChild(l, splitNode._children[j]);
                        splitNode._children[j] = null;
                        splitNode._childCount--;
                    }   //END OF IF STATEMENT
                }   //END OF FOR LOOP
            }   //END OF IF STATEMENT
            splitNode._keyCount = _minKeyCount;
            for (int x = _keyCount; x >= index + 1; x--)
            {
                _children[x + 1] = _children[x];
            }   //END OF FOR LOOP
            _children[index + 1] = newNode;
            _childCount++;
            AddItem(splitNode._keys[_minKeyCount], splitNode._values[_minKeyCount]);
            splitNode._keys[_minKeyCount] = default(TKey);
            splitNode._values[_minKeyCount] = default(TValue);
        }   //END OF SplitChild METHOD

        /// <summary>
        /// Inserts into a tree whose root node is not full already
        /// !!! Recursive function 
        /// </summary>
        /// <param name="key">A generic key</param>
        /// <param name="value">A generic value</param>
        public void InsertNonFull(TKey key, TValue value)
        {
            if(IsLeaf)
            {
                AddItem(key, value);
            }   //END OF IF STATEMENT
            else
            {
                int i = KeyCount - 1;
                while (i >= 0 && _keys[i].CompareTo(key) > 0 ) i--;
                    i++;

                if (_children[i]._keyCount == _keys.Length)
                {
                    SplitChild(i);
                    if (_keys[i].CompareTo(key) < 0)
                        i++;
                }   //END OF IF STATEMENT
                _children[i].InsertNonFull(key, value);
            }   //END OF ELSE STATEMENT
        }  //END OF InsertNonFull METHOD

        /// <summary>
        /// Modified recursive binary search
        /// </summary>
        /// <param name="key">The key used to see if the key exist</param>
        /// <returns>A Generic value relating to the key or the Value we 
        /// were looking for</returns>
        public TValue Find(TKey key)
        {
            int found = Array.IndexOf(_keys, key);
            if (found != -1)
            {
                return _values[found];
            }   //END OF IF STATEMENT
            else
            {
                if (IsLeaf)
                {
                    return default(TValue);
                }   //END OF IF STATEMENT
                else
                {
                    int i;
                    for(i = 0; i < _keyCount; i++)
                    {
                        if(_keys[i].CompareTo(key) > 0)
                        {
                            break;
                        }   //END OF IF STATEMENT
                    }   //END OF FOR LOOP
                    return _children[i].Find(key);
                }   //END OF ELSE STATEMENT
            }   //END OF ELSE STATEMENT
        }   //END OF Find METHOD

        /// <summary>
        /// Overrides the system to return the key as a string
        /// </summary>
        /// <returns>A string for each node</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _keys.Length; i++)
            {
                if (_keys[i] != null && _keys[i].Equals(default(TKey)) == false)
                {
                    if (i == KeyCount - 1)
                        sb.Append(Convert.ToString(_keys[i]));
                    else
                        sb.Append(Convert.ToString(_keys[i] + " | "));
                }   //END OF IF STATEMENT
            }   //END OF FOR LOOP
            return sb.ToString();
        }   //END OF ToString METHOD
    }   //END OF CLASS
}   //END OF PROGRAM