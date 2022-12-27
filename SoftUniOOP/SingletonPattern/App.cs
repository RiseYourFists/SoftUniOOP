using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class App
    {
        private static App instance;
        private static object lockObject = new();

        protected App()
        {

        }

        public static App Instance 
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new App();
                            Console.WriteLine("New instance has occurred!");
                        }
                    }
                }

                return instance;
            }
            
        }

        public void Execute()
        {
            Console.WriteLine("Executing!");
        }
    }
}
