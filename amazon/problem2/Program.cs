using System;
using System.Collections.Generic;
using System.Linq;
namespace problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Test1());
            Console.WriteLine(Test2());
            Console.WriteLine(Test3());


        }

        static int Test1()
        {
            int[,] arr = new int[,]
            {
                {6,1,6}, 
                {4,5,7}, 
                {2,3,8}
            };
            int value = maxOfMinAltitudes(3, 3, arr);
            return value;
        }
        static int Test2()
        {
            int[,] arr = new int[,]
            {
                {1,2,3}
            };
            int value = maxOfMinAltitudes(3, 1, arr);
            return value;
        }

        static int Test3()
        {
            int[,] arr = new int[,]
            {
                {1},
                {2},
                {3}
            };
            int value = maxOfMinAltitudes(1, 3, arr);
            return value;
        }

        static int Test4()
        {
            int[,] arr = new int[,]
            {
                {1},
                {2},
                {3}
            };
            int value = maxOfMinAltitudes(1, 3, arr);
            return value;
        }

        public static int maxOfMinAltitudes(int columnCount, int rowCount, int[,] mat)
        {
            if (mat == null)
                return 0;
            // WRITE YOUR CODE HERE
            // need to find a way to explore the paths. 
            int maxValue = -1;
            foreach (List<int> paths in explorePaths(mat, 0, 0, columnCount, rowCount))
            {
                int min = paths.Min(x => x);
                if (maxValue < min)
                {
                    maxValue = min;
                }
            }
            return maxValue;
        }

        public static List<List<int>> explorePaths(int[,] mat, int i, int j, int columnCount, int rowCount)
        {
            List<List<int>> path1 = new List<List<int>>();
            List<List<int>> path2 = new List<List<int>>();
            if (i < rowCount -1) {
                path1 = explorePaths(mat, i + 1, j, columnCount, rowCount);
                foreach(List<int> path in path1) 
                {
                    path.Add(mat[i,j]);
                }
            }
            if (j < columnCount -1 )
            {
                path2 = explorePaths(mat, i , j + 1, columnCount, rowCount);
                foreach(List<int> path in path2) 
                {
                    path.Add(mat[i,j]);
                }
            }
            if (i == columnCount -1 && j == rowCount - 1)
            {
                List<List<int>> ret = new List<List<int>>();
                ret.Add(new List<int>(8));
                return ret;
            }
            return path1.Concat(path2).ToList();
        }
    }
}
