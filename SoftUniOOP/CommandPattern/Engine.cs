using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter command;

        public Engine(ICommandInterpreter command)
        {
            this.command = command;
        }

        public void Run()
        {
            string input;
            while (true)
            {
                try
                {
                    input = Console.ReadLine();

                    var output = command.Read(input);

                    Console.WriteLine(output);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}