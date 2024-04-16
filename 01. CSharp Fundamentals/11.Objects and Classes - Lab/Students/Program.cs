using System.Text;

namespace Students
{
    public class Students
    {
        public Students(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            HomeTown = homeTown;
            Age = age;
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=string.Empty;
            List<Students> studentsCollection = new List<Students>();
           
            while ((input = Console.ReadLine()) != "end")
            {
                List<string> studentInformation = input
                    .Split()
                    .ToList();
                    
                string firstName = studentInformation[0];
                string lastName = studentInformation[1];
                int age = int.Parse(studentInformation[2]);
                string HomeTown = studentInformation[3];
               Students students = new Students(firstName,lastName,age,HomeTown);
               studentsCollection.Add(students);    
            }
            string cityName=Console.ReadLine();
            PrintStudents(studentsCollection, cityName);
            

        }

        private static void PrintStudents(List<Students> studentsCollection, string? cityName)
        {
            foreach (Students students in studentsCollection)
            {
                if (students.HomeTown == cityName)
                {
                    Console.WriteLine($"{students.FirstName} {students.LastName} is {students.Age} years old.");
                }
            }
        }
    }
}