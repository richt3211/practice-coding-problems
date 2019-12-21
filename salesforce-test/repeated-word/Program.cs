using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace repeated_word
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            firstRepeatedWord("He had had quite enough of this nonsense.");
        }

        static string firstRepeatedWord(string s)
        {
            HashSet<string> wordSet = new HashSet<string>();
            // string[] substrings = Regex.Split(s, @"[a-zA-Z]+");
            string[] substrings = Regex.Split(s, @"\W+");
            foreach (string str in substrings)
            {
                if (wordSet.Contains(str)) 
                {
                    return str;
                }
                else 
                {
                    wordSet.Add(str);
                }
            }
            return "";
        }
    }
}
