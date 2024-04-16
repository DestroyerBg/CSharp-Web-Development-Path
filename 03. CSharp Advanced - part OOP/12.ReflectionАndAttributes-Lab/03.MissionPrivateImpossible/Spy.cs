using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string searchClass, params string[] fieldsToSearch)
        {
            Type type = Type.GetType(searchClass);
            FieldInfo[] fields = type.GetFields(
                BindingFlags.Instance | BindingFlags.Public
                                      | BindingFlags.NonPublic
                                      | BindingFlags.Static);
            Object instance = Activator.CreateInstance(type, new object[] { });
            StringBuilder result = new StringBuilder();
            Console.WriteLine($"Class under investigation: {type}");
            foreach (FieldInfo field in fields.Where(f => fieldsToSearch.Contains(f.Name)))
            {
                result.AppendLine($"{field.Name} = {field.GetValue(instance)}");

            }

            return result.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);
            StringBuilder result = new StringBuilder();
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance
                                                | BindingFlags.Static
                                                | BindingFlags.Public);
                                                 
            MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                result.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in nonPublicMethods.Where(m=>m.Name.StartsWith("get")))
            {
                result.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in publicMethods.Where(m=>m.Name.StartsWith("set")))
            {
                result.AppendLine($"{method.Name} have to be public!");
            }

            return result.ToString().TrimEnd();


        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder result = new StringBuilder();
            result.AppendLine($"All Private Methods of Class: {className}");
            result.AppendLine($"Base Class: {type.Name}");
            foreach (var method in methods)
            {
                result.AppendLine($"{method.Name}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
