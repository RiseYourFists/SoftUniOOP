using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var myStack = new StackOfStrings();
            Console.WriteLine(myStack.IsEmpty());
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            myStack.AddRange(stack);
            Console.WriteLine(myStack.IsEmpty());
        }
    }
}
