using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public class GetDataCommand : BaseCommand
    {
        public override void Execute()
        {
            Console.WriteLine("Getting data...");
        }
    }
}
