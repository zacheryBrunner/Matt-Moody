/*
 * Author: Zachery Brunner
 * Class: UserInterface.cs
 * */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ksu.Cis300.Sort;

namespace Ksu.Cis300.TextAnalyzer
{
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Initializes the components in the GUI
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }   //END OF UserInterface CONSTRUCTOR

        /// <summary>
        /// Method used to Analyze the text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAnalyze_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, WordCount> dictonary = new Dictionary<string, WordCount>();
                int file1Words = TextAnalyzer.ProcessFile(uxText1.Text, 0, dictonary);
                int file2Words = TextAnalyzer.ProcessFile(uxText2.Text, 1, dictonary);
                int[] size = { file1Words, file2Words };
                MinPriorityQueue<float, WordFrequency> wordFrequencies = TextAnalyzer.GetMostCommonWord(dictonary, size, (int)uxNumberOfWords.Value);
                float answer = TextAnalyzer.GetDifference(wordFrequencies);
                MessageBox.Show("Difference Measure: " + answer.ToString());
            }   //END OF TRY BLOCK
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }   //END OF CATCH BLOCK
        }   //END OF uxAnalyze_Click METHOD

        /// <summary>
        /// Event hander for the button Select Text 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSelectText1_Click(object sender, EventArgs e)
        {
            if(uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                uxText1.Text = uxOpenDialog.FileName;
                if (!uxText1.Text.Trim().Equals("") && !uxText2.Text.Trim().Equals(""))
                {
                    uxAnalyze.Enabled = true;
                }   //END OF IF STATEMENT
            }   //END OF IF STATEMENT
        }   //END OF uxSelectText1_Click METHOD

        /// <summary>
        /// Event hander for the button Select Text 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSelectText2_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                uxText2.Text = uxOpenDialog.FileName;
                if (!uxText1.Text.Trim().Equals("") && !uxText1.Text.Trim().Equals(""))
                {
                    uxAnalyze.Enabled = true;
                }   //END OF IF STATEMENT
            }   //END OF IF STATEMENT
        }   //END OF uxSelectText2_Click METHOD
    }   //END OF CLASS
}   //END OF PROGRAM