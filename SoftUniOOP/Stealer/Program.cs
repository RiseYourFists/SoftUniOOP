namespace Stealer
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var spy = new Spy();

            var info = spy.AnalyzeAccessModifiers("Stealer.Hacker");

            Console.WriteLine(info);
        }
    }
}
