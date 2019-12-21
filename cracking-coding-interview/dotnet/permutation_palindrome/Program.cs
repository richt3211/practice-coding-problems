using System;

namespace permutation_palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            permutation_palindrome("Tact Coat");
        }

        static bool permutation_palindrome(string s)
        {
            Console.WriteLine("Testing string: " + s);
            int[] counts = new int[128];
            bool result = true;
            // need to check character counts in string. 
            foreach (char s_ in s)
            {
                int index = (int)Char.ToLower(s_);
                counts[index]++;
            }
            bool found_odd = false;
            foreach (char s_ in s)
            {
                if (Char.IsLetter(s_))
                {
                    int index = (int)Char.ToLower(s_);
                    if (counts[index] % 2 != 0)
                    {
                        if (found_odd)
                        {
                            result = false;
                            break;
                        }
                        found_odd = true;
                    }
                }
            }
            Console.WriteLine("Result is: " + result);
            return result;
        }
    }
}
