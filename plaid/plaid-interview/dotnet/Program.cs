using System;
using System.Collections.Generic;

namespace dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<object[]> test1 = new List<object[]>
            {
                new object[3] { "Netflix", 9.99, 10},
                new object[3] { "Netflix", 9.99, 20},
                new object[3] { "Netflix", 9.99, 30},
                new object[3] { "Amazon", 27.12, 32},
                new object[3] { "Sprint", 50.11, 45},
                new object[3] { "Sprint", 50.11, 55},
                new object[3] { "Sprint", 50.11, 65},
                new object[3] { "Sprint", 60.13, 77},
            };
            RecurringDescription(test1);
        }

        public static void RecurringDescription(List<object[]> list)
        {
            foreach (object[] l in list)
            {
                Console.Write((string)l[0]);
                Console.Write((double)l[1]);
                Console.Write((double)l[2]);
            }
        }

    }
}
