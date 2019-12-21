using System;

namespace ServerLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] A = new int[5]{1,2,3,4,5};
            Console.WriteLine(solution(A));
        }

        static int solution(int[] A) {
            // Your solution goes here.
            Array.Sort(A);
            bool odd = A.Length % 2 != 0;
            int count1 = 0;
            int start;
            if (odd)
            {
                count1 = A[0];
                start = 1;
            }
            else 
                start = 0;
            int count2 = 0;
            int number = 1;
            // int bound = odd ? A.Length/2 +1 : A.Length/2;
            for (int i = start; i < A.Length; i++) {
                if (number == 1)
                {
                    // count1 += i == A.Length/2 ? A[i] : A[i] + A[maxIndex];
                    count1 += A[i] + A[A.Length - i];
                    number = 2;
                }
                else if (number == 2)
                {
                    count2 += A[i] + A[A.Length -i];
                    number = 1;
                }
            }
            return Math.Abs(count2 - count1);
        }
    }
}
