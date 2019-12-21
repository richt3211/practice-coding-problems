using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System;

namespace lucid_programming_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadIO();
            // RunTest1();
            // RunTest2();
        }

        static void ReadIO()
        {
            int res;
        
            int numRows = 0;
            int numCols = 0;
            String[] firstLine = Regex.Split(Console.ReadLine(), @"\s+");
            numRows = Convert.ToInt32(firstLine[0]);
            numCols = Convert.ToInt32(firstLine[1]);

            int[][] grid = new int[numRows][];
            for (int row = 0; row < numRows; row++) {
                String[] inputRow = Regex.Split(Console.ReadLine(), @"\s+");
                int[] gridRow = new int[numCols];

                for (int col = 0; col < numCols; col++) {
                    gridRow[col] = Convert.ToInt32(inputRow[col]);
                }
                grid[row] = gridRow;
            }
            
            res = LongestSubsequence(grid);
            Console.WriteLine(res);
        }


        static void RunTest1()
        {
            int[][]grid = new int[][]
            {
                new int[] {1, 6, 2},
                new int[] {8, 3, 7},
                new int[] {4, 9, 5}
            };
            int longest = LongestSubsequence(grid);
            Console.WriteLine(longest);
        }

        static void RunTest2()
        {
            int[][]grid = new int[][]
            {
                new int[] {4, 2, 4},
                new int[] {0, 3, 1},
                new int[] {3, 7, 9}
            };
            int longest = LongestSubsequence(grid);
            Console.WriteLine(longest);
        }

        static int LongestSubsequence(int[][] grid) 
        {
            int longest = 0;
            for (int i = 0; i < grid.Length; i ++) {
                for (int j = 0; j < grid[0].Length; j ++) {
                    int length = LongestSubsequenceR(grid, i, j, initialize_visited(grid.Length, grid[0].Length) );
                    longest = length > longest ? length : longest;
                }
            }
            return longest;
        }


        static int LongestSubsequenceR(int[][] grid, int i, int j, int[][] visited) 
        {
            // 0; i -1, j -1
            // 1; i -1, j
            // 2; i -1, j + 1
            // 3; i, j + 1
            // 4; i + 1, j + 1
            // 5; i + 1, j
            // 6; i + 1, j -1
            // 7; i, j - 1
            int[] lengths = new int[8];
            bool[] possibilites = new bool[8] {true, true, true, true, true, true, true, true};
            int[][] indexes = new int[8][]
            {
                new int[] {-1, -1}, // 0
                new int[] {-1, 0},  // 1
                new int[] {-1, 1}, // 2
                new int[] {0, 1}, // 3
                new int[] {1, 1}, // 4
                new int[] {1, 0}, // 5
                new int[] {1, -1}, // 6
                new int[] {0, -1}, // 7
            };
            visited[i][j] = 1;
            bool has_visited = false;

            if (i == 0) // can't set p0, p1, or p2
            {
                possibilites[0] = false;
                possibilites[1] = false;
                possibilites[2] = false;
            }
            if (j == 0) // can't set p0, p7, p6
            {
                possibilites[0] = false;
                possibilites[7] = false;
                possibilites[6] = false;
            }
            if (i == grid.Length - 1) // can't set p6, p5, p4
            {
                possibilites[4] = false;
                possibilites[5] = false;
                possibilites[6] = false;
            }
            if (j == grid[0].Length - 1) // can't set p2, p3, p4
            {
                possibilites[2] = false;
                possibilites[3] = false;
                possibilites[4] = false;
            }

            for (int x = 0; x < 8; x++) 
            {
                int i_ = i + indexes[x][0];
                int j_ = j + indexes[x][1];
                if (possibilites[x] && Math.Abs(grid[i_][j_] - grid[i][j]) > 3 && visited[i_][j_]!= 1) 
                {
                    has_visited = true;
                    lengths[x] = LongestSubsequenceR(grid, i_, j_, deep_copy_grid(visited));
                }
            }
            if (!has_visited) 
            {
                return 1;
            }
            int max = lengths.Max();
            return max + 1;
        }
        static int[][] initialize_visited(int i_length, int j_length) 
        {
            int[][] visited = new int[i_length][];
            for (int i =0; i < i_length; i ++) {
                visited[i] = new int[j_length];
            }
            for (int i = 0; i < i_length; i ++) {
                for (int j = 0; j < j_length; j ++) {
                    visited[i][j] = 0;
                }
            }
            return visited;
        }

        static int[][] deep_copy_grid(int[][] arr)
        {
            int[][] copy = new int[arr.Length][];
            foreach (int[] row in arr)
            {

            }
            for (int i = 0; i < arr.Length; i ++) 
            {
                copy[i] = new int[arr[0].Length];
                for (int j =0; j < arr[0].Length; j++) 
                {
                    copy[i][j] = arr[i][j];
                }
            }
            return copy;
        }
    }
}
