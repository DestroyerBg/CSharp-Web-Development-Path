using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Models
{
    public class MyRequiredAttribute:MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
           return obj != null;
        }
    }
}
