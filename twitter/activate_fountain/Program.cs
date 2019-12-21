using System;
using System.Collections.Generic;

namespace activate_fountain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int fountainActivation(List<int> a)
        {
            int count = 0;
            int starting_index = 0;
            int max_index = 0;
            int starting_distance = 0;
            int max_distance = a[starting_index];
            while(starting_distance < a.Count - 1)
            {
                count++;
                for(int i = starting_index; i < a.Count; i++)
                {
                    int bottom = i - a[i];
                    int top = i + a[i];
                    if (bottom <= starting_distance && top >= max_distance)
                    {
                        max_index = i;
                        max_distance = i + a[i];
                    }
                }
                starting_index = max_index;
                starting_distance = starting_index + a[starting_index] + 1;
            }
            if (starting_distance == a.Count -1)
            {
                count++;
            }
            return count;
        }

        # Write your code here
    // starting_index = 0
    // starting_cover = 0
    // furthest_cover = a[starting_index]
    // furthest_index = 0
    // count = 0
    // while starting_cover < len(a) - 1:
    //    count += 1
    //    for i in range(starting_index, len(a)):
    //        if i + a[i] >= furthest_cover and i - a[i] <= starting_cover:
    //            furthest_index = i
    //            furthest_cover = i + a[i]
    //    starting_index = furthest_index
    //    starting_cover = starting_index + a[starting_index] + 1
    // if starting_cover == len(a) - 1:
    //    count += 1
    // return count


    }
}
