using System;

namespace permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "ABC"; 
            int end = str.Length -1;
            permute(str, 0, end);
        }

        static void permute(string str, int l, int r)
        {
            // if we are at the end of the permutation print the string
            if (l == r) 
            {
                Console.WriteLine(str);
            }
            else 
            {
                // we want to loop through every character in the string each time we permute
                for (int i = l; i <=r; i++)
                {
                    // here we swap the ith character with the position in the string that we are at
                    str = swap(str, l, i);
                    // Then we want to permute only the remaining characters in the string
                    permute(str, l + 1, r);
                    // then we swap the string back 
                    str = swap(str, i,l);
                }

            }
        }

        static string swap(string str, int l, int r)
        {
            // need to swap the characters in the string and return new string
            char[] cArray = str.ToCharArray();
            char temp = cArray[l];
            cArray[l] = cArray[r];
            cArray[r] = temp;
            string ret = new string(cArray);
            return ret;
        }
    }
}
