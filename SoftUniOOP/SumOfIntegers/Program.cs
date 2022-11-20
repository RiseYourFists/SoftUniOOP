using System;

namespace SumOfIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var sum = 0;
            foreach (var item in input)
            {
                var num = 0;
                try
                {
                    num = TryGetInt32(item);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    num = 0;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    num = 0;
                }
                finally
                {
                    sum = ProcessSum(sum, num, item);
                }
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }

        private static int ProcessSum(int sum, int num, string element)
        {
            sum += num;
            Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
            return sum;
        }

        private static int TryGetInt32(string element)
        {
            if (long.TryParse(element, out var longNum))
            {
                var max = (long.Parse(int.MaxValue.ToString()));
                var min = (long.Parse(int.MinValue.ToString()));

                if (longNum >= min && longNum <= max)
                {
                    var intNum = int.Parse(longNum.ToString());
                    return intNum;
                }
                throw new Exception($"The element '{element}' is out of range!");
            }
            throw new FormatException($"The element '{element}' is in wrong format!");
        }
    }
}
