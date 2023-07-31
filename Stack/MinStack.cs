using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DS.Stack
{
    public class MinStack
    {

        int[] arr;
        int idx = -1;
        int min = int.MaxValue;


        Stack<(int, int)> stack;

        public MinStack()
        {
            stack = new Stack<(int, int)>();
        }

        public void Push(int val)
        {
            if (stack.Count == 0)
            {
                stack.Push((val, val));
                return;
            }


            var top = stack.Peek();
            stack.Push((val, Math.Min(val, top.Item2)));
        }

        public void Pop()
        {
            idx--;
        }

        public int Top()
        {
            return arr[idx];
        }

        public int GetMin()
        {
            return min;
        }

        public void MinStack_Main()
        {
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(-0);
            minStack.Push(-3);
        }
    }

}
