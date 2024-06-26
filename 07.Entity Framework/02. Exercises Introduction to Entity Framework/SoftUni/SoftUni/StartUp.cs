using SoftUni.Data;
using System.Text;
using SoftUni.Models;

namespace SoftUni
{

    public class StartUp
    {
        public static void Main()
        {
            var context = new SoftUniContext();
            Console.WriteLine(RemoveTown(context));
        }

        //03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary,
            }).ToList();
            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //04

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName, e.Salary
                }).Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();
            var sb = new StringBuilder();

            employees.ForEach(e => sb.AppendLine($"{e.FirstName} - {e.Salary:F2}"));

            return sb.ToString().TrimEnd();
        }

        //05 

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department,
                    e.Salary
                }).Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ToList();
            var sb = new StringBuilder();

            employees.ForEach(e => sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}"));

            return sb.ToString().TrimEnd();
        }

        //06

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address();
            address.AddressText = "Vitoshka 15";
            address.TownId = 4;

            context.Addresses.Add(address);

            var employee = context.Employees.First(e => e.LastName == "Nakov");
            employee.Address = address;


            context.SaveChanges();

            var employees = context.Employees
                .Select(e => new
                {
                    e.Address
                }).OrderByDescending(e => e.Address.AddressId)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            employees.ForEach(e => sb.AppendLine($"{e.Address.AddressText}"));

            return sb.ToString().TrimEnd();

        }

        //07

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    EmployeeName = $"{e.FirstName} {e.LastName}",
                    ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                    Projects = e.EmployeesProjects
                        .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                                               ep.Project.StartDate.Year <= 2003)
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = $"{ep.Project.StartDate:M/d/yyyy h:mm:ss tt}",
                            EndDate = ep.Project.EndDate.HasValue ? $"{ep.Project.EndDate:M/d/yyyy h:mm:ss tt}" : "not finished",
                        })                           
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            employees.ForEach(e =>
            {
                sb.AppendLine($"{e.EmployeeName} - Manager: {e.ManagerName}");
                if (e.Projects.Count() > 0)
                {
                    foreach (var project in e.Projects)
                    {
                        sb.AppendLine(
                            $"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
                    }
                }
            });

            return sb.ToString().TrimEnd();
        }

        //08

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(a => new
                {
                    EmployeesCount = a.Employees.Count,
                    a.AddressText,
                    TownName = a.Town.Name
                })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            addresses.ForEach(a => sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees"));

            return sb.ToString().TrimEnd();
        }

        //09

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees.First(e => e.EmployeeId == 147);
            var projects = context.EmployeesProjects
                .Where(ep => ep.EmployeeId == 147)
                .Select(ep => new
                {
                    ep.Project.Name
                }).OrderBy(ep => ep.Name)
                .ToList();
            var sb = new StringBuilder();
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        //10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments.Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    EmployeesCount = d.Employees.Count,
                    DepartmentName = d.Name,
                    ManagerName = $"{d.Manager.FirstName} {d.Manager.LastName}",
                    Employees = d.Employees.Select(e => new
                    {
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        EmployeeJobTitle = e.JobTitle,
                    }).OrderBy(e => e.EmployeeFirstName)
                        .ThenBy(e => e.EmployeeLastName)
                        .ToList(),

                }).OrderBy(d => d.EmployeesCount).ThenBy(d => d.DepartmentName);

            var sb = new StringBuilder();
            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerName}");
                if (department.Employees.Any())
                {
                    foreach (var employee in department.Employees)
                    {
                        sb.AppendLine(
                            $"{employee.EmployeeFirstName} {employee.EmployeeLastName} - {employee.EmployeeJobTitle}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
            
        }

        //11

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects.OrderByDescending(p => p.StartDate).Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                }).OrderBy(p => p.Name)
                .ToList();

            var sb = new StringBuilder();
            projects.ForEach(p =>
            {
                sb.AppendLine($"{p.Name}");
                sb.AppendLine($"{p.Description}");
                sb.AppendLine($"{p.StartDate:M/d/yyyy h:mm:ss tt}");
            });

            return sb.ToString().TrimEnd();
        }

        //12

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.Department.Name == "Engineering"
                                                         || e.Department.Name == "Tool Design"
                                                         || e.Department.Name == "Marketing"
                                                         || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToArray();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }


            return sb.ToString().TrimEnd();

            
        }

        //13

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.FirstName
                .StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();
            var sb = new StringBuilder();
            employees.ForEach(e => sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})"));

            return sb.ToString().TrimEnd();
        }

        //14

        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeeProject = context.EmployeesProjects.Where(e => e.ProjectId == 2);
            context.RemoveRange(employeeProject);

            var project = context.Projects.FirstOrDefault(e => e.ProjectId == 2);

            context.Remove(project);

            context.SaveChanges();

            var projects = context.Projects.Take(10).ToList();

            var sb = new StringBuilder();
            projects.ForEach(p => sb.AppendLine($"{p.Name}"));

            return sb.ToString().TrimEnd();
        }

        //15

        public static string RemoveTown(SoftUniContext context)
        {
            var employeesInSeattle = context.Employees.Where(e => e.Address.Town.Name == "Seattle").ToList();
            employeesInSeattle.ForEach(e => e.AddressId = null);

            var addressesInSeattle = context.Addresses.Where(e => e.Town.Name == "Seattle").ToList();

            context.RemoveRange(addressesInSeattle);

            var town = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

            context.Remove(town);

            context.SaveChanges();

            return $"{addressesInSeattle.Count()} addresses in Seattle were deleted";
        }
    }
}
