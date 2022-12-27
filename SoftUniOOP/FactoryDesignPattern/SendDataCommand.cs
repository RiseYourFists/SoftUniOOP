using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public class SendDataCommand : BaseCommand
    {
        public override void Execute()
        {
            Console.WriteLine("Sending data...");
        }
    }
}
