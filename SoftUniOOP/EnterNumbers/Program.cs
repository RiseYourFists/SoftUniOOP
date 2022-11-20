using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int validNumCount = 0;
            var validNum = new List<int>();

            while (validNumCount < 10)
            {
                try
                {
                    if (GetValidNum(validNum))
                        validNumCount++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(", ", validNum));
        }

        static bool GetValidNum(List<int> nums)
        {
            Predicate<int> predicate;

            if (nums.Count == 0)
            {
                predicate = x => x > 1 && x < 100;
            }
            else
            {
                predicate = x => x > nums[^1] && x < 100;
            }

            if (int.TryParse(Console.ReadLine(), out int num))
            {
                var restrictionNum = (nums.Count > 0)? nums[^1] : 1; 
                if (!predicate(num))
                {
                    throw new ArgumentException($"Your number is not in range {restrictionNum} - 100!");
                }
                nums.Add(num);
                return true;
            }

            throw new ArgumentException("Invalid Number!");
        }
    }
}
