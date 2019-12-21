using System;

namespace _2d_array_hourglass
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int[][] arr = new int[6][];

            for (int i = 0; i < 6; i++) {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int result = hourglassSum(arr);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }

        static int hourglassSum(int[][] arr) {
            int sum = -100;
            for (int i = 0; i < arr.Length; i++) 
            {
                for (int j = 0; j < arr.Length; j++) {
                    if ( (i != 0 && j !=0 && i != arr.Length - 1 && j != arr.Length - 1 ) {
                        sum_temp = calculateSum(arr);
                        sum = sum_temp > sum ? sum_temp : sum;
                    }
                }
            }
        }

        static int calculateSum(int[][] arr, int i, int j) {
            int sum = 0;
            sum += arr[i - 1][j -1];
            sum += arr[i - 1][j];
            sum += arr[i - 1][j+1];

            sum += arr[i][j];

            sum += arr[i + 1][j-1];
            sum += arr[i + 1][j];
            sum += arr[i + 1][j + 1];
            return sum;
        }
    }
}
