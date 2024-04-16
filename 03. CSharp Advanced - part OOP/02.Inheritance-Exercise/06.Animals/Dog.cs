﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Animals
{
    public class Dog : Animal
    {
        private const string DefaultSound = "Woof!";
        public Dog(string name, int age, string gender) : base(name, age, gender)
        {
        }


        public override string ProduceSound() => DefaultSound;
        

    }
}
