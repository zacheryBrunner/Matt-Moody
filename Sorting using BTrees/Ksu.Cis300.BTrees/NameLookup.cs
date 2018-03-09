/* NameLookup.cs
 * Author: Zachery Brunner
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;
using System.Windows.Forms;
using System.IO;

namespace Ksu.Cis300.BTrees
{
    public partial class NameLookup : Form
    {
        /// <summary>
        /// Initializes the Components
        /// </summary>
        public NameLookup()
        {
            InitializeComponent();
        }   //END OF NameLookup CONSTRUCTOR

        /// <summary>
        /// Globally stores the tree that is created by reading
        /// in a name information file
        /// </summary>
        private BTree<string, NameInformation> _names;

        /// <summary>
        /// Used to read the file and intitialize _names
        /// </summary>
        /// <param name="fn">Holds the fileName</param>
        /// <returns>A tree containing all the names</returns>
        private BTree<string, NameInformation> ReadFile(string fn)
        {
            int minDegree = Convert.ToInt32(uxMinDegree.Text);
            BTree<string, NameInformation> newTree = new BTree<string, NameInformation>(minDegree);
            using (StreamReader input = new StreamReader(fn))
            {
                while(!input.EndOfStream)
                {
                    string name = input.ReadLine().Trim();
                    float frequency = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());
                    NameInformation newName = new NameInformation(name, frequency, rank);
                    newTree.Insert(name, newName);
                }   //END OF WHILE-LOOP
                return newTree;
            }   //END OF USING STATEMENT
        }   //END OF ReadFile METHOD

        /// <summary>
        /// Used for testing a debugging my code
        /// Creates a B-tree with the key and value type as integer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxMakeTree_Click(object sender, EventArgs e)
        {
            int minDegree = Convert.ToInt32(uxMinDegree.Value);
            BTree<int, int> newTree = new BTree<int, int>(minDegree);
            for(int i = 1; i <= Convert.ToInt32(uxCount.Value); i++)
            {
                newTree.Insert(i, i);
            }   //END OF FOR LOOP
            new TreeForm(newTree, 100).Show();
        }   //END OF uxMakeTree_Click METHOD

        /// <summary>
        /// Opens a OpenFilDialog box for selecting a name information text file
        /// Loads file into names by calling the ReadFile method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _names = ReadFile(uxOpenDialog.FileName);
                    new TreeForm(_names, 100).Show();
                }   //END OF TRY
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }   //END OF CATCH
            }   //END OF IF STATEMENT
        }   //END OF uxOpen_Click METHOD

        /// <summary>
        /// Take the text from name TextBox and search for it in the _names B-tree
        /// by calling Find method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLookup_Click(object sender, EventArgs e)
        {
            string name = uxName.Text.Trim().ToUpper();
            NameInformation nameInfo = _names.Find(name);
            if(nameInfo.Name == null)
            {
                MessageBox.Show("Name Not Found");
                uxFrequency.Clear();
                uxRank.Clear();
            }   //END OF IF STATEMENT
            else
            {
               uxFrequency.Text = _names.Find(name).Frequency.ToString();
                uxRank.Text = _names.Find(name).Rank.ToString();
            }   //END OF ELSE STATEMENT
        }   //END OF uxLookup_Click
    }   //END OF CLASS
}   //END OF PROGRAM
