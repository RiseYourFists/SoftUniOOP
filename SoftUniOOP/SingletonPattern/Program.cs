using System;
using System.Net.Http.Headers;
using System.Threading;

namespace SingletonPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var thread = new Thread(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    App.Instance.Execute();
                }   
            });

            var thread2 = new Thread(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    App.Instance.Execute();
                }
            });

            thread.Start();
            thread2.Start();
        }
    }
}
