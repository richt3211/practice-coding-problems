using System;
using System.Collections.Generic;
using System.Linq;

namespace anagram_difference
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static List<int> getMinimumDifference(List<string> a, List<string> b)
        {
            List<int> ret = new List<int>();
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].Length != b[i].Length)
                {
                    ret.Add(-1);
                }
                else 
                {
                    string a_ = a[i];
                    string b_ = b[i];
                    Dictionary<char, int> counts = new Dictionary<char, int>();
                    for (int j = 0; j < a_.Length; j++)
                    {
                        if (counts.ContainsKey(a_[j]))
                        {
                            counts[a_[j]]++;
                        }
                        else
                        {
                            counts.Add(a_[j], 1);
                        }
                        if (counts.ContainsKey(b_[j]))
                        {
                            counts[b_[j]]--;
                        }
                        else
                        {
                            counts.Add(b_[j], -1);
                        }
                        

                    }
                    int difference = 0;
                    foreach (int s in counts.Values)
                    {
                        if (s > 0)
                            difference += s;
                    }
                    ret.Add(difference);
                }
            }
            return ret;
        }
    }
}
