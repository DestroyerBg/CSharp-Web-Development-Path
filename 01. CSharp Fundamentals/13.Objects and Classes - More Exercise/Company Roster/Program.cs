namespace Company_Roster
{
    internal class Program
    {
        class Employee
        {
            public Employee(string employeeName, decimal salary, string department)
            {
                
                Name = employeeName;
                Salary = salary;
                Department = department;
            }

            public string Name { get; set; }
            public decimal Salary { get; set; }
            public string Department { get; set; }
            public override string ToString()
            {
                return $"{Name} {Salary:f2}";
            }
        }

        static void Main(string[] args)
        {
            int numberOfEmployees= int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            var salaries = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string employeeName = arguments[0];
                decimal salary= decimal.Parse(arguments[1]);
                string department = arguments[2];
                Employee employee = new Employee(employeeName, salary,department);
                employees.Add(employee);
                if (!salaries.ContainsKey(department))
                {
                    salaries.Add(department, new List<decimal>());
                }
                salaries[department].Add(salary);
                
            }

            decimal highestSalary= Decimal.MinValue;
            string highestAverageSalaryDepartment=string.Empty;
            foreach (var department in salaries)
            {
                if (department.Value.Average()>highestSalary)
                {
                    highestAverageSalaryDepartment = department.Key;
                    highestSalary= department.Value.Average();
                }
            }

            Console.WriteLine($"Highest Average Salary: {highestAverageSalaryDepartment}");
            var emplooyesInHighestDepartment = employees.Where(x => x.Department == highestAverageSalaryDepartment);
            emplooyesInHighestDepartment = emplooyesInHighestDepartment.OrderByDescending(x => x.Salary);
            foreach (var employ in emplooyesInHighestDepartment)
            {
                Console.WriteLine($"{employ.ToString()}");
            }


        }
    }
}