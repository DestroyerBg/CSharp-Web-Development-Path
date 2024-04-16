using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string KittensGender = "female";
        private const string KittenDefaultSound = "Meow";
        public Kitten(string name, int age) : base(name, age, KittensGender)
        {
        }

        public override string ProduceSound() => KittenDefaultSound;
        
    }
}
