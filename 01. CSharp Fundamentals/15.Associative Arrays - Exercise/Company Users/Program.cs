namespace Company_Users
{
    class Company
    {
        public Company(string companyName, List<string> employersId)
        {
            Name = companyName;
            EmplyersID = employersId;
        }
            


        public string Name { get; set; }
        public List <string> EmplyersID { get; set; }
        public override string ToString()
        {
            string result=string.Empty;
            result= $"{Name}\n";
            for (int i = 0; i < EmplyersID.Count; i++)
            {
                result += $"-- {EmplyersID[i]}\n";
            }
            return result.Trim() ;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            var company = new Dictionary<string, Company>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] companyData=input
                    .Split(" -> ")
                    .ToArray();
                string companyName = companyData[0];
                string employeeID = companyData[1];
                if (!company.ContainsKey(companyName))
                {
                    Company newCompany=new Company(companyName,new List<string>());
                    company.Add(companyName,newCompany);
                    company[companyName].EmplyersID.Add(employeeID);
                    continue;
                }

                if (company.ContainsKey(companyName))
                {
                    var check= company[companyName].EmplyersID.Contains(employeeID);
                    if (check==false)
                    {
                        company[companyName].EmplyersID.Add(employeeID);
                        continue;
                    }
                }

               

            }

            foreach (var pair in company)
            {
                Console.WriteLine($"{pair.Value}");
            }
        }
    }
}