using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public CommandInterpreter()
        {
        }

        public string Read(string args)
        {
            var tokens = args.Split(' ');
            var typeInfo = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == tokens[0] + "Command");

            if (typeInfo == null)
                throw new InvalidOperationException("Invalid command");

            var isCommand = typeInfo.GetInterface("ICommand");

            if (isCommand == null)
                throw new InvalidCastException("Missing ICommand");

            var value = tokens.Skip(1).ToArray();

            var command = Activator.CreateInstance(typeInfo) as ICommand;
            
            return command.Execute(value);
        }

    }
}