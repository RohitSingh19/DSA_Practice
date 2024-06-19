using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DS.Tree
{
   
    public class BinaryTree
    {
        public int totalCount = 0;
        public int previousLevel = -1;
        
        public List<List<int>> result = new List<List<int>>();

        List<int> arr1 = new List<int>();
        List<int> arr2 = new List<int>();
        public int counter = 0;
        public int ans = 0;
        public Node root;
        public class Node
        {
            public Node left, right = null;
            public int data;
            public Node(int d)
            {
                data = d;
            }
        }
       

        public void BTMain()
        {
            BinaryTree binaryTree = new BinaryTree();
            binaryTree.root = new Node(5);
            binaryTree.root.left = new Node(3);
            binaryTree.root.right = new Node(6);
            binaryTree.root.left.left = new Node(2);
            binaryTree.root.left.right = new Node(4);
            binaryTree.root.left.left.left = new Node(1);
            //binaryTree.root.left.right.left = new Node(7);
            //binaryTree.root.left.right.right = new Node(4);
            //binaryTree.root.right.left = new Node(0);
            //binaryTree.root.right.right = new Node(8);
            ////binaryTree.root.right.left = new Node(6);
            //binaryTree.root.right.right = new Node(7);
            //binaryTree.root.right.right.left = new Node(9);
            //binaryTree.root.right.right.right = new Node(10);
            //var result = LevelOrder(binaryTree.root);
            //PrintLevelOrderReverse(binaryTree.root);
            //recursiveInorder(binaryTree.root);
            //PostOrderIterativeWithOneStack(binaryTree.root);

            //string s = "a b c";
            //string[] arr = s.Split(" ");


            //binaryTree.root.left.left = new Node(4);
            //binaryTree.root.left.right = new Node(5);



            //binaryTree.root.right.right.right = new Node(9);

            //var result = IsMirroTree(binaryTree.root.left, binaryTree.root.right);
            //VerticalTraversal(binaryTree.root);
            //binaryTree.ZigzagLevelOrder(binaryTree.root);
            //binaryTree.RootToNodeAllPath(binaryTree.root, result, new List<int>());
            //string abc = binaryTree.serialize(binaryTree.root);
            //Node node = binaryTree.deserialize(abc);

            //var ans = GoodNodes(binaryTree.root);

            var uttar = KthSmallest(binaryTree.root, 3);
        }

        public int GoodNodes(Node root)
        {
            CountGoodNodes(root, root.data);
            return totalCount;
        }

        public int KthSmallest(Node root, int k)
        {
            counter = k;
            helper(root, counter);
            return ans;
        }

        private void helper(Node root, int counter)
        {
            if (root.left != null) helper(root.left,counter);

            counter--;

            if (counter == 0)
            {
                ans = root.data;
                return;
            }
            if (root.right != null) helper(root.right, counter);
        }

        private void CountGoodNodes(Node node, int prevCount)
        {
            if (node == null) return;
            CountGoodNodes(node.left, node.data);
            if (node.data >= prevCount) totalCount++;
            CountGoodNodes(node.right, node.data);
        }
        public int MaxLevelSum(Node root)
        {
            List<List<int>> levels = new List<List<int>>();
            levelOrderTraversal(root, levels);

            int maxSum = levels[0][0];
            int smallestLevel = 1;

            int level = 1;
            while (level < levels.Count)
            {
                List<int> currLevelList = levels[level];
                int currLevelSum = currLevelList.Sum();

                if (currLevelSum > maxSum)
                {
                    smallestLevel = level + 1;
                }
                level++;
            }

            return smallestLevel;
        }

        public void levelOrderTraversal(Node node, List<List<int>> levels)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            while (q.Count > 0)
            {
                int level = q.Count;
                var list = new List<int>();
                while (level > 0)
                {
                    Node n = q.Dequeue();
                    list.Add(n.data);

                    if (n.left != null)
                        q.Enqueue(n.left);

                    if (n.right != null)
                        q.Enqueue(n.right);

                    level--;
                }
                levels.Add(list);
            }
        }
        public string serialize(Node root)
        {
            if (root == null)
                return "";

            StringBuilder sb = new StringBuilder();
            Queue<Node> q = new Queue<Node>();

            
            

            q.Enqueue(root);

            while (q.Count > 0)
            {
                Node node = q.Dequeue();
                if (node == null)
                {
                    sb.Append("N ");
                    continue;
                }

                sb.Append(node.data + " ");

                q.Enqueue(node.left);
                q.Enqueue(node.right);
            }
            return sb.ToString();
        }

        // Decodes your encoded data to tree.
        public Node deserialize(string data)
        {
            if (data == null || data.Length == 0)
                return null;

            /*Converting the string into string array by split method so that it will remove all spaces b/w strings*/

            string[] input = data.Split(" ");

            Queue<Node> q = new Queue<Node>();

            /*create the root node by taking the first element form the array and parse it to integer*/

            Node root = new Node(int.Parse(input[0]));

            q.Enqueue(root);

            for (int i = 1; i < input.Length - 1; i++)
            {
                Node parent = q.Peek();

                if (input[i] != "N")
                {
                    Node left = new Node(int.Parse(input[i]));
                    parent.left = left;
                    q.Enqueue(left);
                }
                if (input[++i] != "N")
                {
                    Node right = new Node(int.Parse(input[i]));
                    parent.right = right;
                    q.Enqueue(right);
                }
            }

            return root;
        }

        public void helper(Node root, List<int> list, int targetSum)
        {
            if (root == null)
                return;

            list.Add(root.data);

            helper(root.left, list, targetSum);

            helper(root.right, list, targetSum);

            int sum = 0;

            int idx = list.Count - 1;

            while (idx > 0 && sum != targetSum)
            {
                sum += list[idx];

                idx--;

                if (sum == targetSum)
                {
                    counter++;
                }
            }

            list.RemoveAt(list.Count - 1);
        }
        public bool SumTree(Node root)
        {
            if (root == null || isLeaf(root))
                return true;

            SumTree(root.left);
            SumTree(root.right);

            int LSum = root.left != null ? root.left.data : 0;
            int RSum = root.right != null ? root.right.data : 0;

            if (LSum + RSum == root.data)
            {
                root.data = LSum + RSum + root.data;
                return true;
            }
            return false;
        }


        public void RootToNodeAllPath(Node node, List<List<int>> result, List<int> list)
        {
            if (node == null)
                return;

            List<int> recurList = new List<int>(list);

            recurList.Add(node.data);

            if (isLeaf(node)) {
                result.Add(recurList);
                return;
            }

            RootToNodeAllPath(node.left, result, recurList);
            RootToNodeAllPath(node.right, result, recurList);
        }
        public Node LowestCommonAncestor(Node root, Node p, Node q)
        {

            //base case 
            if (root == null || p == root || q == root)
            {
                return root;
            }


            Node Left = LowestCommonAncestor(root.left, p, q);
            Node Right = LowestCommonAncestor(root.right, p, q);

            if (Left == null)
                return Right;
            else if (Right == null)
                return Left;
            else
                return root;
        }

        //private List<int> VerticalTraversal(Node root)
        //{ 

        //    Dictionary<int, List<int>> hash = new Dictionary<int, List<int>>();
        //    VerticalTraversalHelper(root, 0, hash);
        //    IList<int> result = new List<int>();

        //    foreach (KeydatauePair<int, List<int>> keydatauePair in hash.OrderBy(x=> x.Key))
        //    {
        //        keydatauePair.dataue.ForEach(x =>
        //        {
        //            result.Add(x);
        //        });
        //    }

        //    return result;
        //}


        int isSumTree(Node node)
        {
            if (node == null)
                return 0;

            int ls; // for sum of nodes in left subtree
            int rs; // for sum of nodes in right subtree

            ls = isSumTree(node.left);
            if (ls == -1) // To stop for further traversal of
                          // tree if found not sumTree
                return -1;

            rs = isSumTree(node.right);
            if (rs == -1) // To stop for further traversal of
                          // tree if found not sumTree
                return -1;

            if (isLeaf(node) || ls + rs == node.data)
                return ls + rs + node.data;
            else
                return -1;
        }


        bool isLeaf(Node node)
        {
            return (node!=null && node.left == null && node.right == null);   
        }
        //bool helper(Node root, int level)
        //{

        //    if(root == null)
        //        return false;

        //    if (isLeaveNode(root))
        //    {
        //        if (previousLevel != -1 && previousLevel != level)
        //            return false;

        //        previousLevel = level;
        //        return true;
        //    }

        //    if (helper(root.left, level + 1))
        //        return true;

        //    if (helper(root.right, level + 1))
        //        return true; 

        //    return false;
        //}

        public IList<IList<int>> ZigzagLevelOrder(Node root)
        {
            var result = new List<IList<int>>();
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                int level = q.Count;
                IList<int> list = new List<int>();
                for (int i = 0; i < level; i++)
                {
                    Node node = q.Dequeue();

                    list.Add(node.data);

                    if (node.left != null)
                        q.Enqueue(node.left);

                    if (node.right != null)
                        q.Enqueue(node.right);
                }
                if ((level % 2 == 0))
                {
                    var res = list.Reverse();
                    result.Add(res.ToList());
                }
                else
                {
                    result.Add(list);
                }
            }
            return result;
        }
        //private void VerticalTraversalHelper(Node root, int level, Dictionary<int, List<int>> hash)
        //{
        //    if (root == null)
        //        return;

        //    VerticalTraversalHelper(root.left, level - 1,hash);

        //    if (hash.ContainsKey(level))
        //    {
        //        List<int> list = hash.GetdataueOrDefault(level);
        //        list.Add(root.data);
        //        list.Sort();
        //        hash[level] = list;
        //    }
        //    else
        //    {
        //        hash[level] = new List<int>() { root.data};
        //    }

        //    VerticalTraversalHelper(root.right, level + 1, hash);
            
        //}

        private bool IsMirroTree(Node left, Node right)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(left);
            q.Enqueue(right);

            while (q.Count > 0)
            {
                Node l = q.Dequeue();
                Node r = q.Dequeue();

                if (l == null && r == null) continue;
                if(l == null || r == null || r.data != l.data)
                    return false;

                q.Enqueue(l.left);
                q.Enqueue(r.right);
                q.Enqueue(l.right);
                q.Enqueue(r.left);

            }
            return true;
        }

        private void PostOrderIterative(Node root)
        { 
            List<int> ints = new List<int>();
            Stack<Node> s1 = new Stack<Node>();
            Stack<Node> s2 = new Stack<Node>();

            s1.Push(root);

            while (s1.Count > 0)
            {
                Node curr = s1.Peek();
                s1.Pop();
                s2.Push(curr);

                if(curr.left!=null)
                    s1.Push(curr.left);

                if (curr.right != null)
                    s1.Push(curr.right);
            }

            while (s2.Count > 0)
            {
                ints.Add(s2.Pop().data);
                Console.Write(" "+s2.Pop().data);
            }
        }

        private void PostOrderIterativeWithOneStack(Node root)
        {

            Stack<Node> stack = new Stack<Node>();

            while (root != null || stack.Count > 0)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else 
                {
                    Node temp = stack.Peek().right;
                    if (temp == null)
                    {
                        temp = stack.Peek();
                        stack.Pop();
                        Console.Write(" " + temp.data);
                        //previous pop out node is equal to current node in stack's peek right. means this is a root node whose right is already printed
                        while (stack.Count > 0 && temp == stack.Peek().right) 
                        {
                            temp = stack.Peek();
                            stack.Pop();
                            Console.Write(" " + temp.data);
                        }
                    }
                    else
                    {
                        root = temp;
                    }
                }
            }
        
        }


        private void recursiveInorder(Node root)
        {
            if (root == null) 
                return;

            recursiveInorder(root.left);
            Console.Write(root.data + " ");
            recursiveInorder(root.right);
        }

        public void LevelOrderTraversal(Node root)
        {
            Queue<Node> q = new Queue<Node>();

            q.Enqueue(root);

            while (q.Count > 0)
            { 
            
                Node node = q.Dequeue();

                Console.WriteLine(node.data);

                if (node.left != null)
                    q.Enqueue(node.left);

                if (node.right != null)
                    q.Enqueue(node.right);
            }
        }


        public void PrintLevelOrderReverse(Node root)
        {
            int height = Height(root);
            for (int i = height; i >= 1; i--)
            {
                PrintLevelOrder(root, i);
            }
        }

        private void PrintLevelOrder(Node root, int level)
        {
            if (root == null)
                return;

            if (level == 1)
                Console.WriteLine(root.data);

            PrintLevelOrder(root.left, level-1);
            PrintLevelOrder(root.right, level - 1);
        }

        public int Height(Node root)
        {
            if (root == null)
                return 0;

            int LHeight = Height(root.left);
            int RHeight = Height(root.right);

            return LHeight > RHeight ? LHeight + 1 : RHeight + 1;
        }

        public Stack<List<int>> LevelOrder(Node root)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            Stack<List<int>> result = new Stack<List<int>>();
            while (q.Count > 0)
            {
                int level = q.Count;
                var list = new List<int>();
                while (level > 0)
                {
                    
                    Node node = q.Dequeue();

                    list.Add(node.data);

                    if (node.left != null)
                        q.Enqueue(node.left);

                    if (node.right != null)
                        q.Enqueue(node.right);


                    level--;
                }
                result.Push(list);
            }
            return result;
        }


        public Node Invert(Node root)
        {
            if (root == null)
                return root;

            Node mirror = new Node(root.data);

            mirror.left = Invert(root.right);
            mirror.right = Invert(root.left);

            return mirror;
        }
    }
}
