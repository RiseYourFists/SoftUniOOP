using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]

    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }

    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
            => obj != null;
    }

    public class MyRangeAttribue : MyValidationAttribute
    {
        private readonly int minValue;

        private readonly int maxValue;

        public MyRangeAttribue(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            var num = (int)obj;

            return num >= minValue && num <= maxValue;
        }
    }
}
