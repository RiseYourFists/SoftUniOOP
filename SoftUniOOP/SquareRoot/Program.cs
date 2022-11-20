using System;

namespace SquareRoot
{
    public class Program
    {
        static void Main(string[] args)
        {
			var num = int.Parse(Console.ReadLine());
			try
			{
				if (num < 0)
				{
					throw new ArgumentException("Invalid number.");
				}
				Console.WriteLine(Math.Sqrt(num));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				Console.WriteLine("Goodbye.");
			}
		}
	}
}
