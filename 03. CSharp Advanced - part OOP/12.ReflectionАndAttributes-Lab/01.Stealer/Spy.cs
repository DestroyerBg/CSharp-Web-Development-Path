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
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            Object instance = Activator.CreateInstance(type, new object[] { });
            StringBuilder result = new StringBuilder();
            Console.WriteLine($"Class under investigation: {type}");
            foreach (FieldInfo field in fields.Where(f=>fieldsToSearch.Contains(f.Name)))
            {
                result.AppendLine($"{field.Name} = {field.GetValue(instance)}");

            }
            return result.ToString().TrimEnd();
        }
    }
}
