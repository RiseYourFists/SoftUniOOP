namespace Stealer
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var spy = new Spy();

            var info = spy.StealFieldInfo("Stealer.Hacker", new string[] {"username", "password" });

            Console.WriteLine(info);
        }
    }
}
