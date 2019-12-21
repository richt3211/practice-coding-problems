using System;
using System.Collections.Generic;
using System.Linq;
namespace show_tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<int> tickets = new List<int>{2,6,3,4,5};
            Console.WriteLine( waitingTime2(tickets, 2));

            tickets = new List<int>{1, 1, 1, 1, 0};
            Console.WriteLine( waitingTime2(tickets, 0));

            tickets = new List<int>{2,6,3,4,5,1};
            Console.WriteLine( waitingTime2(tickets, 2));
        }

        static long waitingTime(List<int> tickets, int p)
        {
            Queue<int[]>q = new Queue<int[]>();
            for(int i = 0; i < tickets.Count; i++)
            {
                int num_to_insert = i == p ? 1 : 0;
                q.Enqueue(new int[2]{tickets[i], num_to_insert});
            }
            int count = 0;
            while (true)
            {
                int[] value = q.Dequeue();
                value[0] --;
                if (value[0] != 0)
                {
                    q.Enqueue(value);
                }
                count++;
                if (value[1] == 1)
                {
                    if (value[0] == 0)
                    {
                        return count;
                    }
                }
            }
        }

        static long waitingTime2(List<int> tickets, int p)
        {
            int number = tickets[p];
            List<int> lessThanBefore = tickets.GetRange(0, p).Where(x => x < number).ToList();
            List<int> lessThanAfter = tickets.GetRange(p + 1, tickets.Count - (p + 1)).Where(x => x < number).ToList();
            long ret = (long)(p + 1) + (long)((long)(number - 1) * (long)tickets.Count);
            foreach (int x in lessThanBefore)
            {
                ret -= (number - x);
            }
            foreach (int x in lessThanAfter)
            {
                ret -= (number - x) - 1;
            }
            return ret;
        }
    }
}
