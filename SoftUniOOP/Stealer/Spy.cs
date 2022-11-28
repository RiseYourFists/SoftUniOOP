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

        public string AnalyzeAccessModifiers(string className)
        {
            var typeInfo = Type.GetType(className);

            var output = new StringBuilder();

            var classInstance = Activator.CreateInstance(typeInfo);

            var fields = typeInfo.GetFields((BindingFlags)(4|8|16));
            var publicMethods = typeInfo.GetMethods((BindingFlags)(4 | 16));
            var nonPublicMethods = typeInfo.GetMethods((BindingFlags)(4 | 32));

            foreach (var field in fields)
            {
                output.AppendLine($"{field.Name} must be private");
            }
            foreach (var method in publicMethods.Where(p => p.Name.StartsWith("get")))
            {
                output.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in nonPublicMethods.Where(p => p.Name.StartsWith("set")))
            {
                output.AppendLine($"{method.Name} have to be private!");
            }

            return output.ToString();
        }
    }
}
