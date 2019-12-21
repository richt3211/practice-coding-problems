using System;

namespace problem1
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
            NodeList head1 = new NodeList(1);
            head1.next = new NodeList(2);
            head1.next.next = new NodeList(3);
            head1.next.next.next = new NodeList(4);
            
            NodeList head2 = new NodeList(1);
            head2.next = new NodeList(3);
            head2.next.next = new NodeList(5);
            head2.next.next.next = new NodeList(7);

            NodeList ret = mergeLists(head1, head2);

        }

        static void Test2()
        {
            NodeList head1 = new NodeList(1);
            
            NodeList head2 = new NodeList(2);

            NodeList ret = mergeLists(head1, head2);

        }

        static void Test3()
        {
            NodeList head1 = new NodeList(1);
            
            NodeList head2 = new NodeList(2);

            NodeList ret = mergeLists(head1, head2);

        }

        public static NodeList mergeLists(NodeList head1, NodeList head2)  
        {
            if (head1 == null && head2 != null ) 
                return head2;
            else if (head1 != null && head2 == null) 
                return head1;
            else if (head1 == null && head2 == null)
                return null;
            NodeList head1Current = head1;
            NodeList head2Current = head2;
            NodeList ret;
            if (head1Current.data <= head2Current.data) 
            {
                ret = new NodeList(head1Current.data);
                head1Current = head1Current.next;
            }
            else 
            {
                ret = new NodeList(head2Current.data);
                head2Current = head2Current.next;
            }
            NodeList retCurrent = ret;
            while (head1Current != null || head2Current != null) 
            {
                // do something
                // if value in 1 is less than 2, add value 1 to array. 
                if (head1Current != null && (head2Current == null || head1Current.data <= head2Current.data)) {
                    retCurrent.next = new NodeList(head1Current.data);
                    head1Current = head1Current.next;
                }
                else if (head2Current != null && (head1Current == null || head1Current.data > head2Current.data)) {
                    retCurrent.next = new NodeList(head2Current.data);
                    head2Current = head2Current.next;
                }
                retCurrent = retCurrent.next;

            }
            return ret;
        }
    }

    public class NodeList 
    {
        public int data;
        public NodeList next;
        public NodeList(int data)
        {
            this.data = data;
            next = null;
        }
    }
}
