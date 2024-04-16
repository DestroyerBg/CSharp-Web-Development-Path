using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T Left { get; set; }
        private T Right { get; set; }
        public EqualityScale(T left, T right)
        {
            this.Left = left;
            this.Right = right;
        }
        public bool AreEqual()
        {
            return Left.Equals(Right);
        }

       
    }
}
