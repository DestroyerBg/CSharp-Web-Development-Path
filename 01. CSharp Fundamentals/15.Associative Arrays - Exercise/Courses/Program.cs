namespace Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            var course = new Dictionary<string, List<string>>();
            while ((input = Console.ReadLine()) != "end")
            {
                string[] courseInfo = input
                    .Split(" : ")
                    .ToArray();
                string courseName= courseInfo[0];
                string student= courseInfo[1];
                if (!course.ContainsKey(courseName))
                {
                    course.Add(courseName, new List<string>());
                    course[courseName].Add(student);
                    continue;
                }
                course[courseName].Add(student);



            }

            foreach (var pair in course)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.Count}");
                foreach (var value in pair.Value)
                {
                    Console.WriteLine($"-- {value}");
                }
            }
        }
    }
}