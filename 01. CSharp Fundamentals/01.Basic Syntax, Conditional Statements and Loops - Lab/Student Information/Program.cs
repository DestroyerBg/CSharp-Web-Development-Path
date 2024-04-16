string studentName=Console.ReadLine();
sbyte age=sbyte.Parse(Console.ReadLine());
float averageGrade=float.Parse(Console.ReadLine());
Console.WriteLine($"Name: {studentName}, Age: {age}, Grade: {averageGrade:f2}");