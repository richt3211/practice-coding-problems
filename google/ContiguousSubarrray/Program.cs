using System;
using System.Collections.Generic;

namespace ContiguousSubarrray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] a = new int[]{1,4,3,2,5,4};
            int[] result = solution(a,4);
            printResult(result);

            a = new int[]{0,1,2,3,4,5,6,7,8,9,10};
            result = solution(a,1);
            printResult(result);
        }

        static void printResult(int[] a)
        {
            foreach(int x in a)
            {
                Console.Write(x.ToString() + ",");
            }
            Console.WriteLine();
        }

        static int[] solution(int[] arr, int k)
        {
            // List<int[]> subArrays = new List<int[]>();
            int[] maxArray = new int[k];
            for(int i = 0; i < arr.Length; i++)
            {
                int[] currentArray = new int[k];
                if (i + k <= arr.Length)
                {
                    Array.Copy(arr, i, currentArray, 0, k);
                }
                // subArrays.Add(currentArray);
                if (compareArrays(currentArray, maxArray) == 1) 
                {
                    maxArray = currentArray;
                }
            }
            return maxArray;
        }

        static int compareArrays(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return arr1[i] > arr2[i] ? 1 : 2;
                }
            }
            return 1;
        }
    }
}
