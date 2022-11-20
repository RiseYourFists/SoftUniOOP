using System;
using System.Linq;

namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var exceptionsCount = 0;

            while (exceptionsCount < 3)
            {
                var command = Console.ReadLine().Split();
                var action = command[0];
                try
                {
                    var index = TryGetIndex(command[1]);

                    switch (action)
                    {
                        case "Replace":
                            int endIndex;
                            Replace(elements, command[2], index);
                            break;
                        case "Show":
                            Show(elements, index);
                            break;
                        case "Print":
                            endIndex = Print(elements, command, index);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    exceptionsCount++;
                }
            }
            Console.WriteLine(string.Join(", ", elements));
        }

        private static int Print(int[] elements, string[] command, int index)
        {
            int endIndex = TryGetIndex(command[2]);
            if (IsInRange(index, endIndex, elements))
            {
                var sheet = elements[index..(endIndex + 1)];
                Console.WriteLine(string.Join(", ", sheet));
            }

            return endIndex;
        }

        private static void Show(int[] elements, int index)
        {
            if (IsInRange(index, elements))
            {
                Console.WriteLine(elements[index]);
            }
        }

        private static void Replace(int[] elements,string element, int index)
        {
            if (IsInRange(index, elements))
            {
                elements[index] = int.Parse(element);
            }
        }

        private static bool IsInRange(int index, int[] arr)
        {
            if (index >= 0 && index < arr.Length - 1)
            {
                return true;
            }
            throw new Exception("The index does not exist!");
        }

        private static bool IsInRange(int index, int endIndex, int[] arr)
        {
            if (index < arr.Length - 1 
                && index >= 0 
                && endIndex >= 0 
                && endIndex <= arr.Length - 1)
            {
               return true;
            }
            throw new Exception("The index does not exist!");
        }

        private static int TryGetIndex(string index)
        {
            if (int.TryParse(index, out int i))
            {
                return i;
            }
            throw new Exception("The variable is not in the correct format!");
        }
    }
}
