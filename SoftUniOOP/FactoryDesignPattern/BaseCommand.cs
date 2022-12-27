using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public abstract class BaseCommand : ICommand
    {
        public virtual  void Execute()
        {
            Console.WriteLine("Doing nothing");
        }
    }
}
