using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace dynamic_array
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int q = Convert.ToInt32(firstMultipleInput[1]);

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            List<int> result = dynamicArray(n, queries);

            textWriter.WriteLine(String.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();
        }

        public static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            List<List<int>> seqList = new List<List<int>>();
            for (int i = 0; i < n; i++) 
            {
                seqList.Insert(i, new List<int>());
                // seqList[i] = new List<int>();
            }
            List<int> answers = new List<int>();
            int lastAnswer = 0;
            foreach (List<int> query in queries) 
            {
                int x = query[1];
                int y = query[2];
                int index = (x ^ lastAnswer) % n;
                if (query[0] == 1) 
                {
                    seqList[index].Add(y);
                }
                if (query[0] == 2) 
                {
                    List<int> seq = seqList[index];
                    int index2 = y % seq.Count;
                    lastAnswer = seq[index2];
                    answers.Add(lastAnswer);
                }
            }
            return answers;
        }
    }
}
