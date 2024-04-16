using System.Security.Cryptography.X509Certificates;

namespace Oldest_Family_Member
{
    internal class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }

    

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople= int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personInfo = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name= personInfo[0];
                int age= int.Parse(personInfo[1]);
                Person person = new Person(name, age);
                persons.Add(person);
            }

            int oldestMemberAge = persons.Max(x => x.Age);
            string oldestMemberName = persons.FirstOrDefault(x => x.Age == oldestMemberAge).Name;
            Console.WriteLine($"{oldestMemberName} {oldestMemberAge}");

        }

        
    }

}