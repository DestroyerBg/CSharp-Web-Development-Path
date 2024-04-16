using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = data[0];
                int age = int.Parse(data[1]);
                Person person = new Person(name, age);
                persons.Add(person);
            }
           var filterPersons = persons.FindAll(p=>p.Age>30).OrderBy(p=>p.Name);
           foreach (var person in filterPersons)
           {
               Console.WriteLine(person.ToString());
           }
        }
    }
}