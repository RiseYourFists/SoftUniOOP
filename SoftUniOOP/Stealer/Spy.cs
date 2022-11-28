namespace Stealer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string className, string[] fieldsToInvestigate)
        {
            Type typeInfo = Type.GetType(className);

            List<FieldInfo> fields = typeInfo.GetFields((BindingFlags)62).ToList();

            var classInstance = Activator.CreateInstance(typeInfo, new object[] { });

            var output = new StringBuilder();

            output.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo field in fields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                output.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return output.ToString();

        }
    }
}
