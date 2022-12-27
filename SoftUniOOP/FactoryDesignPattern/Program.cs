using System;

namespace FactoryDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var terminal = new Terminal()
                .GetCommand()
                .ExecuteCommand(Action.GetData)
                .ExecuteCommand(Action.ReadData)
                .ExecuteCommand(Action.WriteData)
                .ExecuteCommand(Action.SendData);
        }
    }
}
