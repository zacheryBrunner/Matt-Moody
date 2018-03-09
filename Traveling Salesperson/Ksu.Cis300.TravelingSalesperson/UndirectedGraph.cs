/* 
 * Author: Zachery Brunner
 * Class: UndirectedGraph.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TravelingSalesperson
{
    class UndirectedGraph
    {
        /// <summary>
        /// Two dimensioal array that holds the information for the undirected graph
        /// </summary>
        private int[,] _adjMatrix;

        /// <summary>
        /// String representation of each node
        /// </summary>
        private List<string> _nodes = new List<string>();

        /// <summary>
        /// Number of nodes in the graph
        /// </summary>
        private int _size;

        /// <summary>
        /// Public constructor for UndirectedGraph
        /// </summary>
        /// <param name="size">Used to initialize all private fields</param>
        public UndirectedGraph(int size)
        {
            _size = size;
            _adjMatrix = new int[size, size];
        }   //END OF UndirectedGraph CONSTRUCTOR

        /// <summary>
        /// Adds a string representation of a node to the list of nodes _nodes
        /// </summary>
        /// <param name="data">String represetation of the node</param>
        private void AddNode(string data)
        {
            if (_nodes.Count == _size)
            {
                throw new InvalidOperationException();
            }   //END OF IF STATEMENT
            else
            {
                _nodes.Add(data);
            }   //END OF ELSE STATEMENT
        }   //END OF AddNode

        /// <summary>
        /// Returns the string representation of a node at a given index
        /// </summary>
        /// <param name="index">Used to get the node</param>
        /// <returns>String representation of the node</returns>
        public string GetNode(int index)
        {
            return _nodes[index];
        }   //END OF GetNode METHOD

        /// <summary>
        /// Adds an edge to the graph by first checking to see if an edge exist and then
        /// either adding it or comparing to see what the least resistant path is
        /// </summary>
        /// <param name="source">Original "Town" or node</param>
        /// <param name="destination">Destination "Town" or node</param>
        /// <param name="weight">The resistance along the path connecting the two "Towns" or nodes</param>
        public void AddEdge(string source, string destination, int weight)
        {
            int sourceIndex = _nodes.IndexOf(source);
            int destinationIndex = _nodes.IndexOf(destination);
            if(sourceIndex < 0)
            {
                sourceIndex = _nodes.Count;
                AddNode(source);
            }   //END OF IF STATEMENT
            if(destinationIndex < 0)
            {
                destinationIndex = _nodes.Count;
                AddNode(destination);
            }   //END OF IF STATEMENT
            _adjMatrix[sourceIndex, destinationIndex] = weight;
            _adjMatrix[destinationIndex, sourceIndex] = weight;
        }   //END OF AddEdge METHOD

        /// <summary>
        /// Calculates the minimum cost spanning tree of the graph by using Prim's algorithm
        /// </summary>
        /// <returns>The root of the tree</returns>
        public MSTNode GetMinSpanningTree()
        {
            MSTNode[] spanningTree = new MSTNode[_size];
            bool[] nodesAdded = new bool[_size];
            for (int i = 1; i < _size; i++)
            {
                spanningTree[i] = new MSTNode(Int32.MaxValue, 0, _nodes[i]);
            }   //END OF FOR LOOP
            spanningTree[0] = new MSTNode(0, -1, _nodes[0]);
            int minIndex = -1;
            for (int i = 0; i < _size; i++)
            {
                int min = Int32.MaxValue;
                for(int j = 0; j < _size; j++)
                {
                    if(!nodesAdded[j] && spanningTree[j].Data < min)
                    {
                        min = spanningTree[j].Data;
                        minIndex = j;
                    }   //END OF IF STATEMENT
                }   //END OF FOR LOOP
                nodesAdded[minIndex] = true;
                if(i != 0)
                {
                    spanningTree[spanningTree[minIndex].Parent].AddChild(spanningTree[minIndex]);
                }   //END OF IF STATEMENT
                for (int k = 0; k < _size; k++)
                {
                    if (_adjMatrix[minIndex, k] > 0 && !nodesAdded[k] && _adjMatrix[minIndex, k] < spanningTree[k].Data)
                    {
                        spanningTree[k].Data = _adjMatrix[minIndex, k];
                        spanningTree[k].Parent = minIndex;
                    }   //END OF IF STATEMENT
                }   //END OF FOR LOOP
            }   //END OF FOR LOOP
            return spanningTree[0];
        }   //END OF GetMinSpanning METHOD
    }   //END OF CLASS
}   //END OF PROGRAM