/*
 * Author: Zachery Brunner
 * Class: TextAnayler.cs
 * */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Ksu.Cis300.Sort;

namespace Ksu.Cis300.TextAnalyzer
{
    public static class TextAnalyzer
    {
        /// <summary>
        /// Used to compute the difference between the two files
        /// </summary>
        /// <param name="queue">Queue containing the frequencies of the words used in the files</param>
        /// <returns>The difference percentage between the two authors</returns>
        public static float GetDifference(MinPriorityQueue<float, WordFrequency> queue)
        {
            float percentageDifference = 0;
            while (queue.Count > 0)
            {
                WordFrequency x = queue.RemoveMinimumPriority();
                percentageDifference += ((x[0] - x[1]) * (x[0] - x[1]));
            }   //END OF WHILE LOOP
            return (100 * ((float)Math.Sqrt(percentageDifference)));
        }   //END OF GerDifference METHOD

        /// <summary>
        /// Method used to find the highest frequencies of words in each file
        /// </summary>
        /// <param name="dictionary">Gives the number of occurrences of each word in each file</param>
        /// <param name="numberOfWords">Gives the number of words in each file</param>
        /// <param name="num">number of words to get</param>
        /// <returns></returns>
        public static MinPriorityQueue<float, WordFrequency> GetMostCommonWord(Dictionary<string, WordCount> dictionary, int[] numberOfWords, int number)
        {
            MinPriorityQueue<float, WordFrequency> queue = new MinPriorityQueue<float, WordFrequency>();
            foreach (KeyValuePair<string, WordCount> pair in dictionary)
            {
                WordFrequency temp = new WordFrequency(pair.Value, numberOfWords);
                queue.Add(temp[0] + temp[1], temp);
                if (queue.Count > number)
                {
                    queue.RemoveMinimumPriority();
                }   //END OF IF STATEMENT
            }   //END OF FOREACH LOOP
            return queue;
        }   //END OF GetMostCommonWord METHOD
        
        /// <summary>
        /// Processes the file givin in the fileName param
        /// </summary>
        /// <param name="fileName">Gives the name of the file to Read</param>
        /// <param name="fileNumber">Gives the file number: Either 0 or 1</param>
        /// <param name="numberOfOccurrences">Number of occurrences of each word in any previous file</param>
        /// <returns>Total number of words within the file read</returns>
        public static int ProcessFile(string fileName, int fileNumber, Dictionary<string, WordCount> numberOfOccurrences)
        {
            int numberOfWords = 0;
            using (StreamReader input = new StreamReader(fileName))
            {
                while (!input.EndOfStream)
                {
                    string line = input.ReadLine().ToLower();
                    string[] words = Regex.Split(line, "[^abcdefghijklmnopqrstuvwxyz]+");
                    foreach (string word in words)
                    {
                        if (word != "")
                        {
                            WordCount wordCount;
                            if (!(numberOfOccurrences.TryGetValue(word, out wordCount)))
                            {
                                wordCount = new WordCount(word, 2);
                                numberOfOccurrences.Add(word, wordCount);
                            }   //END OF IF STATEMENT
                            wordCount.Increment(fileNumber);
                            numberOfWords++;
                        }   //END OF IF STATEMENT
                    }   //END OF FOREACH LOOP
                }   //END OF WHILE LOOP
            }   //END OF USING STATEMENT
            return numberOfWords;
        }   //END OF ProcessFile
    }   //END OF CLASS
}   //END OF PROGRAM