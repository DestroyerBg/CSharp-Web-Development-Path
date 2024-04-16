using System.Net.Http.Headers;

namespace Student_Academy
{
    class Student
    {
        public Student(string studentName)
        {
            Name = studentName;
            Grade = new List<double>();
        }

        public string Name { get; set; }
        public List<double> Grade { get; set; }
        public override string ToString()
        {
            return $"{Name} -> {Grade.Average():f2}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var studentsDatabase = new Dictionary<string, Student>();
            int rowsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < rowsNumber; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!studentsDatabase.ContainsKey(studentName))
                {
                    Student newStudent = new Student(studentName);
                    studentsDatabase.Add(studentName, newStudent);
                    studentsDatabase[studentName].Grade.Add(grade);
                    continue;


                }
                studentsDatabase[studentName].Grade.Add(grade);





            }

            var filteredStudents = studentsDatabase.Where(g => g.Value.Grade.Average() >= 4.50);
            
            foreach (var pair in filteredStudents)
            {
                Console.WriteLine($"{pair.Value}");
            }





        }
    }
}