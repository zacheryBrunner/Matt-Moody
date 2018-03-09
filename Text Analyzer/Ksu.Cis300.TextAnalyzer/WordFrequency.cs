/*
 * Author: Zachery Brunner
 * Class: WordFrequency.cs
 * */
using System;

namespace Ksu.Cis300.TextAnalyzer
{
    public struct WordFrequency
    {
        /// <summary>
        /// Stores the frequency of the word in each file
        /// </summary>
        private float[] _frequencies;

        /// <summary>
        /// Stores a word
        /// </summary>
        private string _word;

        /// <summary>
        /// Gets the frequency of the word in a specific file
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public float this[int index]
        {
            get
            {
                if (index >= _frequencies.Length || index < 0)
                {
                    throw new ArgumentException("Index out of Bounds ");
                }   //END OF IF STATEMENT
                return _frequencies[index];
            }   //END OF GETTER
        }   //END OF this PROPERTY

        /// <summary>
        /// Public property to get the word
        /// </summary>
        public string Word
        {
            get { return _word; }
        }   //END OF Word PROPERTY

        /// <summary>
        /// Public Constructor for WordFrequency
        /// </summary>
        /// <param name="wordCount">Holds the information about a word</param>
        /// <param name="numberOfWords">Number of words in each file is held in the arrary</param>
        public WordFrequency(WordCount wordCount, int[] numberOfWords)
        {
            if (numberOfWords.Length != wordCount.NumberOfFiles)
            {
                throw new ArgumentException("Index out of Bounds ");
            }   //END OF IF STATEMENT
            _frequencies = new float[numberOfWords.Length];
            _word = wordCount.Word;
            for (int i = 0; i < numberOfWords.Length; i++)
            {
                _frequencies[i] = wordCount[i] / (float)numberOfWords[i];
            }   //END OF FOR LOOP
        }   //END OF WordFrequency CONSTRUCTOR
    }   //END OF CLASS
}   //END OF PROGRAM