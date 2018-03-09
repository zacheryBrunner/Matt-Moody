/*
 * Author: Zachery Brunner
 * Class: WordCount.cs
 * */
using System;

namespace Ksu.Cis300.TextAnalyzer
{
    public class WordCount
    {
        /// <summary>
        /// Stores the number of occurrences of the word in each file
        /// </summary>
        private int[] _counts;

        /// <summary>
        /// Storing a word
        /// </summary>
        private string _word;

        /// <summary>
        /// Public property to get the number of files being processed
        /// </summary>
        public int NumberOfFiles
        {
            get { return _counts.Length; }
        }   //END OF numOfFiles PROPERTY
        
        /// <summary>
        /// Gets the number of occurrences of the word in a specified file
        /// </summary>
        /// <param name="loc">File number</param>
        /// <returns></returns>
        public int this[int fileNumber]
        {
            get
            {
                if(fileNumber >= _counts.Length)
                {
                    throw new ArgumentException("Index out of Bounds ");
                }   //END OF IF STATEMENT
                return _counts[fileNumber];
            }   //END OF GETTER
        }   //END OF indexer PROPERTY

        /// <summary>
        /// Public property to get the word
        /// </summary>
        public string Word
        {
            get { return _word; }
        }   //END OF Word PROPERTY

        /// <summary>
        /// Takes a file number and increments the word
        /// </summary>
        /// <param name="fileLoc">FileNumber</param>
        public void Increment(int fileLoc)
        {
            if(fileLoc < _counts.Length && fileLoc >= 0)
            {
                _counts[fileLoc]++;
                return;
            }   //END OF IF STATEMENT
            throw new ArgumentException("Index Out of Bounds");
        }   //END OF WordFrequency METHOD

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="word">The word</param>
        /// <param name="numOfFiles">An int used for initalizing the array</param>
        public WordCount(string word, int numOfFiles)
        {
            _word = word;
            _counts = new int[numOfFiles];
        }   //END OF CONSTRUCTOR
    }   //END OF CLASS
}   //END OF PROGRAM