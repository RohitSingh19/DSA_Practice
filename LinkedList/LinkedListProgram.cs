using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.LinkedList
{
    public class LinkedListProgram
    {
        public Node head;
        public Node head1;
        public class Node
        {
            public int data;
            public Node next;
            public Node(int d)
            {
                data = d;
                next = null;
            }
        }

        private void convertArrayToList()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            Node head = new Node(-1);
            Node temp = head;
            int idx = 0;
            while(idx < arr.Length)
            {
                temp.next = new Node(arr[idx]);
                temp = temp.next;
                idx++;
            }
        }

        public void CallMainForLinkedList()
        {
            LinkedListProgram linkedList = new LinkedListProgram();
            linkedList.convertArrayToList();
            //linkedList.head = new Node(1);
            //linkedList.head.next = new Node(2);
            //linkedList.head.next.next = new Node(3);
            //linkedList.head.next.next.next = new Node(4);
            //linkedList.head.next.next.next.next = new Node(5);
            //linkedList.head.next.next.next.next.next = new Node(6);
            //linkedList.head.next.next.next.next.next.next = new Node(7);
            //linkedList.head.next.next.next.next.next.next.next = new Node(8);
            //linkedList.head.next.next.next.next.next.next.next.next = new Node(9);
            //linkedList.head.next.next.next.next.next.next.next.next.next = new Node(10);

            var ans = linkedList.SplitListToParts(linkedList.head, 5);


            //LinkedListProgram linkedList1 = new LinkedListProgram();
            //linkedList1.head1 = new Node(9);
            //linkedList1.head1.next = new Node(9);
            //linkedList1.head1.next.next = new Node(4);
            //linkedList1.head1.next.next.next = new Node(9);
            //linkedList1.head1.next.next.next.next = new Node(7);
            //linkedList1.head1.next.next.next.next.next = new Node(5);
            //Node node = new Node(100);
            //linkedList.head.next.next.next.next = node;
            //linkedList.insertAtlast(99);
            //linkedList.insertAtHead(0);
            //linkedList.insertAfter(linkedList.head.next, 5000);

            //Node newNode = linkedList.reverseList();
            //Node newNode = linkedList.reverse(linkedList.head);
            //linkedList.ReverseWithStack(linkedList.head);
            //linkedList.displayList(ne);
            //linkedList.intersectionOfList();

            //Node result = linkedList.addOne(linkedList.head);
            //Node result = linkedList.AddNumber(linkedList.head, linkedList1.head1);
            //Node result = linkedList.reverseKGroup(linkedList.head, 3);
            //Node result = linkedList.MergeSort(linkedList.head);
            //LinkedListProgram list1 = new LinkedListProgram();
            //list1.head = new Node(1);
            //list1.head.next = new Node(2);
            //list1.head.next.next = new Node(3);

            //LinkedListProgram list2 = new LinkedListProgram();
            //list2.head = new Node(4);
            //list2.head.next = new Node(5);

            //LinkedListProgram list3 = new LinkedListProgram();
            //list3.head = new Node(5);
            //list3.head.next = new Node(6);

            //LinkedListProgram list4 = new LinkedListProgram();
            //list4.head = new Node(7);
            //list4.head.next = new Node(8);

            //Node[] arr = new Node[] {list1.head, list2.head, list3.head, list4.head };
            //Node result = AddTwoNumbers(linkedList.head, linkedList1.head1);
        }

        public Node[] SplitListToParts(Node head, int k)
        {
            int len = getLength(head);
            int group = len / k;
            int extras = len % k;

            Node [] result = new Node[k];
            Node node = head;
            Node prev = null;
            int idx = 0;
            while (node != null)
            {
                result[idx] = node;
                int curr = group;
                while (curr + extras > 0)
                {
                    prev = node;
                    node = node.next;
                    if (curr == 0)
                        break;
                    if (extras > 0)
                        extras--;
                    else
                        curr--;
                }
                idx++;
                prev.next = null;
            }

            return result.ToArray();
        }

        private int getLength(Node node)
        {
            int len = 0;
            while (node != null)
            {
                node = node.next;
                len++;
            }
            return len;
        }
        public Node ReverseListRecursion(Node head)
        {
            if (head == null || head.next == null) return head;
            Node node = ReverseListRecursion(head.next);

            head.next.next = head;
            head.next = null;
            return node;
        }

        public Node OddEvenList(Node head)
        {
            if (head == null || head.next == null)
                return head;

            Node odd = head; //odd
            Node even = odd.next; //even
            Node EvenHead = odd.next;

            while (odd.next != null && even.next != null)
            {
                odd.next = odd.next.next;
                odd = odd.next;
                even.next = even.next.next;
                even = even.next;
            }
            odd.next = EvenHead;
            return head;
        }
        public int PairSum(Node head)
        {

            Node slow = head;
            Node fast = head;
            Node first = new Node(0);
            Node temp = first;

            while (slow != null && fast != null && fast.next != null)
            {
                temp.next = new Node(slow.data);
                temp = temp.next;
                slow = slow.next;
                fast = fast.next.next;
            }

            first = first.next;
            Node second = ReverseList(slow);
            int maxSum = 0;
            while (second != null && first != null)
            {
                maxSum = Math.Max(first.data + second.data, maxSum);
                first = first.next;
                second = second.next;
            }

            return maxSum;
        }

        public Node ReverseList(Node head)
        {
            Node prev = null;
            Node curr = head;

            while (curr != null)
            {
                Node next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }
        public Node AddTwoNumbers(Node l1, Node l2)
        {
            l1 = Reverse(l1);
            l2 = Reverse(l2);

            int carry = 0;
            Node temp = new Node(-1);
            Node result = temp;
            while (l1 != null || l2 != null)
            {
                int n1 = (l1 != null) ? l1.data : 0;
                int n2 = (l2 != null) ? l2.data : 0;

                int sum = ((n1 + n2) % 10) + carry;
                carry = (n1 + n2) / 10;
                result.next = new Node(sum);
                result = result.next;
                l1 = (l1 != null) ? l1.next : null;
                l2 = (l2 != null) ? l2.next : null;
            }

            if (carry > 0)
            {
                result.next = new Node(carry);
            }

            Node ans = Reverse(temp.next);
            return ans;
        }

        private Node Reverse(Node node)
        {
            Node curr = node;
            Node prev = null;

            while (curr != null)
            {
                Node next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;

        }

        public Node MergeSort(Node head)
        {
            if (head == null || head.next == null)
                return head;

            
            Node mid = GetMiddle(head);
            
            Node left = head;
            Node right = mid.next;

            mid.next = null;

            left = MergeSort(left);
            right = MergeSort(right);

            Node result = Merge(left, right);
            return result;
        }

        private Node Merge(Node left, Node right)
        {
            if (left == null) return right;
            if (right == null) return left;

            Node result = new Node(-1);
            Node temp = result;
            
            while (left != null && right != null)
            {
                if (left.data < right.data)
                {
                    temp.next = left;
                    left = left.next;
                }
                else
                {
                    temp.next = right;
                    right = right.next;
                }

                temp = temp.next;
            }

            while (left != null)
            {
                temp.next = left;
                left = left.next;
                temp = temp.next;
            }
            while (right != null)
            {
                temp.next = right;
                right = right.next;
                temp = temp.next;
            }
            return result.next;
        }

        private Node GetMiddle(Node head)
        {
            Node slow = head;
            Node fast = head.next;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }

        public Node AddNumber(Node n1, Node n2)
        { 
            Stack<Node> s1 = new Stack<Node>();
            Stack<Node> s2 = new Stack<Node>();

            while (n1 != null)
            {
                s1.Push(n1);
                n1 = n1.next;
            }

            while (n2 != null)
            {
                s2.Push(n2);
                n2 = n2.next;
            }

            int carry = 0;
            Node dummy = new Node(0);
            Node temp = dummy;
            while (s1.Count > 0 || s2.Count > 0)
            { 
                int ele1 = s1.Count > 0 ? s1.Pop().data : 0;
                int ele2 = s2.Count > 0 ? s2.Pop().data : 0;

                int sum = ele1 + ele2 + carry;
                int data = sum;
                if (sum > 9) 
                {
                    data = sum % 10;
                    carry = sum / 10;
                }
                temp.next = new Node(data);
                temp = temp.next;
            }

            if (carry > 0) {
                temp.next = new Node(carry);
            }
            return dummy.next;
        }

        


        public Node AddOne(Node node)
        {
            int carry = AddOneUtil(node);
            Node newNode = null;
            if (carry > 0) {
                newNode = new Node(carry);
                newNode.next = node;
                return newNode;
            }

            return node;
        }

        private int AddOneUtil(Node node)
        {
            if (node == null) 
                return 1;

            int data = node.data + AddOneUtil(node.next);
            node.data = data % 10;
            return data / 10;

        }


        //public Node XaddOne(Node head)
        //{
        //    Node temp = head;
        //    string s = string.Empty;
        //    while (temp != null)
        //    {
        //        s += temp.data.ToString();
        //        temp = temp.next;
        //    }

        //    s = (int.Parse(s)+1).ToString();

        //    int i = 0;
        //    Node dummy = new Node(-1);
        //    Node t = dummy;
        //    while (i < s.Length)
        //    {
        //        t.next = new Node(int.Parse(s[i].ToString()));
        //        t = t.next;
        //        i++;
        //    }
        //    return dummy.next;

        //}

        //public Node AddOne(Node head)
        //{
        //    head = reverse(head);
        //    head = AddOneUtil(head);
        //    return reverse(head);
        //}


        public void printListInReverse(Node head)
        {
            Node rev = reverse(head);
            int sum = rev.data + 1;

            Node temp = rev;

        }

        //public Node AddOneUtil(Node node)
        //{
        //    Node res = node;
        //    Node temp = null;
        //    int carry = 1;
        //    int sum = 0;
        //    while (node != null)
        //    {
        //        sum = carry + node.data;
        //        carry = sum > 9 ? 1 : 0;
        //        sum = sum % 10;
        //        node.data = sum;
        //        temp = node;
        //        node = node.next;
        //    }
        //    if (carry > 0)
        //    {
        //        temp.next = new Node(carry);
        //    }
        //    return res;
        //}

        public Node reverseKGroup(Node head, int k)
        {
            Node curr = head;
            Node prev = null;
            Node next = null;
            int count = 0;
            while (count < k)
            {
                if (curr == null)
                {
                    reverseKGroup(prev, count);
                }
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
                count++;

            }
            head.next = reverseKGroup(curr, k);
            return prev;
        }

        public Node XreverseKGroup(Node head, int k)
        {
            if (head == null || k == 1) return null;

            int len = 0;
            Node l = head; //len is the length of this list
            while (l != null)
            {
                len++;
                l = l.next;
            }

            int round = len / k;   //cut the list, so we have 'round' lists with size k 
            if (round == 0) return head;

            Node dummy = new Node(-1);
            dummy.next = head;
            Node prev = dummy, next = dummy, curr = dummy;
            for (int i = 0; i < round; i++)
            {
                //for each list with size k, reverse it 
                curr = prev.next;
                next = curr.next;
                for (int j = 0; j < k - 1; j++)
                {
                    curr.next = next.next;
                    next.next = prev.next;
                    prev.next = next;
                    next = curr.next;
                }
                prev = curr;
            }
            return dummy.next;
        }

        public void displayList()
        {

            Node node = head;
            while (node != null)
            {
                Console.Write(" " + node.data);
                node = node.next;
            }
        }

        public void intersectionOfList()
        {
            Node A = head;
            Node B = head1;
            //1->2->3->4->8->7->5->N
            //10->20->30->8->7->5->N
            while (A != B)
            {
                A = (A == null) ? head1 : A.next;
                B = (B == null) ? head : B.next;
            }

            int intersection = A.data;
        }

        public void displayList(Node head)
        {

            Node node = head;
            while (node != null)
            {
                Console.Write(" " + node.data);
                node = node.next;
            }
        }

        public Node reverseList()
        {
            Node curr = head;
            Node prev = null;

            while (curr != null)
            { 
                Node next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }

        public Node reverse(Node head)
        {
            if (head == null || head.next == null)
                return head;

            // Reverse the rest list and put
            // the first element at the end
            Node rest = reverse(head.next);
            head.next.next = head;

            // Tricky step --
            // see the diagram
            head.next = null;

            // Fix the head pointer
            return rest;
        }


        public void ReverseWithStack(Node head)
        {

            Stack<Node> stack = new Stack<Node>();
            Node temp = head;
            while (temp.next != null)
            {
                stack.Push(temp);
                temp = temp.next; 
            }
            head = temp;
            while (stack.Count > 0)
            { 
                temp.next = stack.Peek();
                stack.Pop();
                temp = temp.next;
            }
            temp.next = null;
        }

        public void deleteNode(int key)
        {
            Node temp = head;
            Node prev = null;

            if (temp != null && temp.data == key)
            {
                head = temp.next;
                return;
            }

            while(temp!=null && temp.data!=key)
            {

                prev = temp;
                temp = temp.next;
            }

            prev.next = temp.next;
        }
       
        public void insertAtlast(int data)
        {
            Node node = head;
            while(node.next != null)
            {
                node = node.next;
            }

            Node newNode = new Node(data);
            node.next = newNode;
        }

        public void insertAtHead(int d)
        {
            if (head == null) {
                head = new Node(d);
                return;
            }

            Node newNode = new Node(d);
            newNode.next = head;
            head = newNode;
        }

        public void insertAfter(Node pre_node, int d)
        {
            Node newNode = new Node(d);
            newNode.next = pre_node.next;
            pre_node.next = newNode;
        }
    }
}
