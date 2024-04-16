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
            string input = string.Empty;
            List<Students> studentsCollection = new List<Students>();

            while ((input = Console.ReadLine()) != "end")
            {
                List<string> studentInformation = input
                    .Split()
                    .ToList();

                string firstName = studentInformation[0];
                string lastName = studentInformation[1];
                int age = int.Parse(studentInformation[2]);
                string homeTown = studentInformation[3];
                

               bool isStudentHere = CheckForStudentAvailability(studentsCollection, firstName, lastName, age, homeTown);
                if (isStudentHere)
                {
                    Students student= GetStudent(studentsCollection,firstName, lastName, age, homeTown);
                    student.FirstName= firstName;
                    student.LastName= lastName;
                    student.Age= age;
                    student.HomeTown= homeTown;
                   
                    
                }
                else
                {
                    studentsCollection.Add(new Students(firstName,lastName,age,homeTown));
                    
                }
            }
            string cityName=Console.ReadLine();
            PrintStudents(studentsCollection,cityName);


        }

        private static void PrintStudents(List<Students> studentsCollection, string cityName)
        {
            foreach (Students students in studentsCollection)
            {
                if (students.HomeTown == cityName)
                {
                    Console.WriteLine($"{students.FirstName} {students.LastName} is {students.Age} years old.");
                }
            }
        }

        private static Students GetStudent(List<Students> studentsCollection,string firstName, string lastName, int age, string homeTown)
        {
            Students currStudent= null;
            foreach (Students students in studentsCollection)
            {
                if (students.FirstName==firstName && students.LastName==lastName)
                {
                    currStudent= students;
                }
            }

            return currStudent;
        }


        private static bool CheckForStudentAvailability(List<Students> studentsCollection, string firstName, string lastName, int age, string city)
        {
            Students student = studentsCollection.Find(students => students.FirstName == firstName && students.LastName == lastName);
            if (student == null)
            {
                return false;

            }

            return true;

        }
    }
}