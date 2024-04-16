using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;
        protected Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid input!");
                }
                name = value;
            }
        }


        public int Age
        {
            get => age;

            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Invalid input!");
                }
                age = value;
            }
        }

        public string Gender
        {
            get => gender;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid input!");
                }
                gender = value;
            }
        }

        public abstract string ProduceSound();

    }
}
