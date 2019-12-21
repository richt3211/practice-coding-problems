using System;
using System.Collections.Generic;
using System.Linq;

namespace authentication_tokens
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<List<int>> commands = new List<List<int>>()
            {
                new List<int>(){0, 1, 1},
                new List<int>(){1, 1, 5}
            };
            numberOfTokens(3, commands);
            commands = new List<List<int>>()
            {
                new List<int>(){0, 1, 1},
                new List<int>(){1, 1, 4},
                new List<int>(){1, 2, 5},
            };
            numberOfTokens(3, commands);

            commands = new List<List<int>>()
            {
                new List<int>(){0, 1, 1},
                new List<int>(){0, 5, 5},
                new List<int>(){1, 1, 12},
                new List<int>(){1, 5, 6},
            };
            Console.WriteLine(numberOfTokens(4, commands));
            commands = new List<List<int>>()
            {
                new List<int>(){0, 1, 1},
                new List<int>(){0, 2, 2},
                new List<int>(){1, 1, 5},
                new List<int>(){1, 2, 7},
                new List<int>(){1, 1, 9},
                new List<int>(){0, 3, 10},
                new List<int>(){0, 4, 12},
                new List<int>(){1, 1, 13},
                new List<int>(){0, 5, 14},

            };
            Console.WriteLine(numberOfTokens(4, commands));

            commands = new List<List<int>>()
            {
                new List<int>(){0, 1, 1},
                new List<int>(){0, 2, 2},
                new List<int>(){1, 1, 5},
                new List<int>(){1, 2, 7},
                new List<int>(){1, 1, 9},
                new List<int>(){0, 3, 10},
                new List<int>(){0, 4, 12},
                new List<int>(){1, 1, 13},
                new List<int>(){0, 5, 14},

            };
            Console.WriteLine(numberOfTokens(4, commands));
        }

        public static int numberOfTokens(int expiryLimit, List<List<int>> commands)
        {
            Dictionary<int, long> nonExpired = new Dictionary<int, long>();
            int maxTime = 0;
            foreach(List<int> command in commands)
            {
                int function = command[0];
                int tokenId = command[1];
                int time = command[2];
                if (time > maxTime)
                    maxTime = time;
                // add token
                if (function == 0)
                {
                    if (!nonExpired.ContainsKey(tokenId))
                    {
                        nonExpired.Add(tokenId, (long)time + (long)expiryLimit);
                    }
                }
                //reset token
                else if (function == 1)
                {
                    // need to check to see if token has expired
                    if (nonExpired.ContainsKey(tokenId))
                    {
                        long expiration_time = nonExpired[tokenId];
                        if (time <= expiration_time)
                        {
                            nonExpired[tokenId] = expiration_time + (long)expiryLimit;
                        }
                        else 
                        {
                            nonExpired.Remove(tokenId);
                        }
                    }
                }
                // List<KeyValuePair<int,long>> keysToRemove = nonExpired.Where(x => x.Value < maxTime).ToList();
                // foreach (KeyValuePair<int,long> x in keysToRemove)
                // {
                //     nonExpired.Remove(x.Key);
                // }
            }
            int count;
            if (nonExpired.Count != 0)
            {
                count = nonExpired.Where(x => x.Value >= maxTime).Count();
            }
            else
            {
                count = 0;
            }
            return count;
        }
    }
}
