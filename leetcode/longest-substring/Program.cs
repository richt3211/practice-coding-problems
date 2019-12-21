using System;
using System.Collections.Generic;
namespace longest_substring
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTest("abcabcbb");
            RunTest("bbbb");
            RunTest("pwwkew");
            RunTest(" ");
            RunTest("");
            RunTest("abcdefgabcdefgh");
        }

        static void RunTest(string s)
        {
            int result;
            Console.WriteLine("Testing " + s);
            result = LongestSubstring(s);
            Console.WriteLine(result);
        }

        static int LongestSubstring(string s)
        {
            if (s == "")
                return 0;
            int longest = 0;
            for (int i = 0; i < s.Length ;i ++) 
            {
                HashSet<char> chars = new HashSet<char>();
                for (int j = i; j < s.Length; j++) 
                {
                    if (!chars.Contains(s[j]))
                    {
                        chars.Add(s[j]);
                        longest = chars.Count > longest ? chars.Count : longest;
                    }
                    else 
                    {
                        longest = chars.Count > longest ? chars.Count : longest;
                        break;
                    }
                }
            }
            return longest;
        }
    }
}
