using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => this.Count == 0;

        public void AddRange(Stack<string> strings)
        {
            for (int i = 0; i < strings.Count; i++)
            {
                this.Push(strings.Pop());
            }
        }
    }
}
