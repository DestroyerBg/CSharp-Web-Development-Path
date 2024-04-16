using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Any())
            {
                return true;
            }
            return false;
        }
        public Stack<string> AddRange(List<string> range)
        {
            foreach (var item in range)
            {
                this.Push(item);
            }
            return this;
        }

    }
}
