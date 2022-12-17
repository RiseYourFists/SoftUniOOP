using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var @this = new This();
            var that = new That(@this);

            Console.WriteLine(@this.IsYes);
            that.This.Change();
            Console.WriteLine(that.This.IsYes);
            Console.WriteLine(@this.IsYes);
        }
    }

    class This : IThis
    {
        private bool isYes;
        public This()
        {
            IsYes = true;
        }
        public bool IsYes { get => isYes; set => isYes = value; }

        public void Change()
        {
            isYes = !isYes;
        }
    }

    class That
    {
        public That(IThis @this)
        {
            This = @this;
        }

        public IThis This { get; set; }
        
    }

    interface IThis
    {
        bool IsYes { get; }

        void Change();
    }
}
