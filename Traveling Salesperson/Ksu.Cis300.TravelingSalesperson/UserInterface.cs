/*
 * Author: Zachery Brunner
 * Class: UserInterface.cs
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KansasStateUniversity.TreeViewer2;
using System.IO;

namespace Ksu.Cis300.TravelingSalesperson
{
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Default constructor for the class
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }   //Default Constructer
        
        /// <summary>
        /// Helper function to read in the data and create a graph
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <returns>A graph containing all the data</returns>
        private UndirectedGraph ReadGraph(string fileName)
        {
            UndirectedGraph graph;
            using (StreamReader input = new StreamReader(fileName))
            {
                int size = Convert.ToInt32(input.ReadLine());
                graph = new UndirectedGraph(size);
                while (!input.EndOfStream)
                {
                    string data = input.ReadLine();
                    string[] splitData = data.Split(',');
                    graph.AddEdge(splitData[0], splitData[1], Convert.ToInt32(splitData[2]));
                }   //END OF WHILE LOOP
            }   //END OF USING STATEMENT
            return graph;
        }   //END OF ReadGraph METHOD

        /// <summary>
        /// Event handler for the Open Button, generates a solution to the traveling 
        /// salesmen proble,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpenButton_Click(object sender, EventArgs e)
        {
            if(uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    UndirectedGraph graph = ReadGraph(uxOpenDialog.FileName);
                    MSTNode parent = graph.GetMinSpanningTree();
                    uxTour.Text = parent.Walk();
                    new TreeForm(parent, 100).Show();
                }catch(Exception ex)
                {
                    MessageBox.Show("This error has occurred " + ex.ToString());
                }   //END OF TRY-CATCH BLOCK               
            }   //END OF IF STATEMENT
        }   //END OF EVENT HANDLER
    }   //END OF CLASS
}   //END OF PROGRAM