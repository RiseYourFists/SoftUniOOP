using System;
using System.Collections.Generic;

namespace FactoryDesignPattern
{
    public class Terminal
    {
        private Dictionary<Action, ICommand> commands = new();

        public Terminal GetCommand()
        {
            foreach (var action in Enum.GetValues(typeof(Action)))
            {
                var command = (ICommand)Activator
                    .CreateInstance(Type.GetType("FactoryDesignPattern." 
                                   + Enum.GetName(typeof(Action), action)
                                   + "Command"));
                commands.Add((Action)action, command);
            }
            return this;
        }

        public Terminal ExecuteCommand(Action action)
        {
            commands[action].Execute();
            return this;
        }
    }
}
