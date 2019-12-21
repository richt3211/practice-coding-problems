using System;

namespace add_two_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
            Test2();
        }

        static void Test1()
        {
            ListNode l1 = new ListNode(2);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(3);

            ListNode l2 = new ListNode(5);
            l2.next = new ListNode(6);
            l2.next.next = new ListNode(4);

            ListNode ret = AddTwoNumbers(l1, l2);
        }
        
        static void Test2()
        {
            ListNode l1 = new ListNode(0);
            ListNode l2 = new ListNode(0);

            ListNode ret = AddTwoNumbers(l1, l2);
        }
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            if (l1 == null) return l1;
            if (l2 == null) return l2;
            int firstNum = 0;
            int secondNum = 0;
            ListNode l1Current = l1;
            ListNode l2Current = l2;
            int mult = 1;
            // need the count of the list? 
            while (l1Current != null) {
                firstNum += l1Current.val * mult;
                l1Current = l1Current.next;
                mult *= 10;
            }
            mult = 1;
            while (l2Current != null) {
                secondNum += l2Current.val * mult;
                l2Current = l2Current.next;
                mult *= 10;
            }
            uint n = 1;
            int finalVal = firstNum + secondNum;
            ListNode ret = new ListNode(finalVal % IntPow(10, n) / IntPow(10, n -1) );
            ListNode retCurrent = ret;
            int count = finalVal / 10;
            bool loop = count / 10 == 0 ? false : true;
            n = 2;
            while (loop) {
                if (count / 10 == 0) loop = false;
                retCurrent.next = new ListNode(finalVal % IntPow(10, n) / IntPow(10, n -1) );
                count /= 10;
                n++;
                retCurrent = retCurrent.next;
            }
            return ret;

        }

        public static int IntPow(int x, uint pow)
        {
            int ret = 1;
            while ( pow != 0 )
            {
                if ( (pow & 1) == 1 )
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) 
        {
            val = x;
        }
    }
}
