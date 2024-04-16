﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name,int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);
            if (result != 0)
            {
                return result;
            }
            return Age.CompareTo(other.Age);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Person compare = obj as Person;
            if (compare == null)
            {
                return false;
            }
            return Name == compare.Name && Age == compare.Age;
        }
    }
}
