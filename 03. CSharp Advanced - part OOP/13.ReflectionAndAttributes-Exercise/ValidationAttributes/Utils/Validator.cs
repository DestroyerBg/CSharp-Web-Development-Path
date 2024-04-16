using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Models;

namespace ValidationAttributes.Utils
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties()
                .Where(
                    p => p.CustomAttributes.Any(c => typeof(MyValidationAttribute)
                        .IsAssignableFrom(c.AttributeType)))
                .ToArray();
            foreach (var property in properties)
            {
                IEnumerable<MyValidationAttribute> properyAttributes = property
                    .GetCustomAttributes(true)
                    .Where(p => typeof(MyValidationAttribute).IsAssignableFrom(p.GetType()))
                    .Cast<MyValidationAttribute>();
                foreach (MyValidationAttribute attribute in properyAttributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
