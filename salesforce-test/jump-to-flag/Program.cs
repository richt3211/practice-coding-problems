using System;

namespace jump_to_flag
{
    class Program
    {
        static void Main(string[] args)
        {
            jumps(3, 1);
            Console.WriteLine(jumps(7,2));
        }



        static int jumps(int k , int j)
        {
            if (k == j)
                return 1;
            int distance = 0;
            int jumps = 0;
            for (int i = distance; i < k - j; i += j)
            {
                jumps++;
                distance += j;
            }
            for (int i = distance; i < k; i++)
            {
                jumps++;
            }
            return jumps;
        }
    }
}
