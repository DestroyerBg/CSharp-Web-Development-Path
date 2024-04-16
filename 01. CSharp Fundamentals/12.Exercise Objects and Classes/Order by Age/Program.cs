namespace Order_by_Age
{
    class Person
    {
        public Person(string personName, string personId, int personAge)
        {
            PersonName = personName;
            PersonID = personId;
            PersonAge = personAge;
        }

        public string PersonName { get; set; }
        public string PersonID { get; set; }
        public int PersonAge { get; set; }
        public override string ToString()
        {
            return $"{PersonName} with ID: {PersonID} is {PersonAge} years old.";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string input=string.Empty;
            List<Person> allPersons = new List<Person>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] humanData= input
                    .Split(" ")
                    .ToArray();
                string personName= humanData[0];
                string personID= humanData[1];
                int personAge = int.Parse(humanData[2]);
                bool checkIfPersonIDIsHere= CheckId(personID,allPersons);
                if (checkIfPersonIDIsHere == true)
                {
                    int indexOfPerson = allPersons.FindIndex(x => x.PersonID == personID);
                    allPersons[indexOfPerson].PersonAge = personAge;
                    allPersons[indexOfPerson].PersonName=personName;
                    continue;
                }
                Person newPerson= new Person(personName,personID,personAge);
                allPersons.Add(newPerson);
            }
            allPersons=allPersons.OrderBy(x=>x.PersonAge).ToList();
            foreach (Person person in allPersons)
            {
                Console.WriteLine($"{person}");
            }
        }
        static bool CheckId(string personId, List<Person> allPersons)
        {
            var check = allPersons.Find(x => x.PersonID == personId);
            if (check!=null)
            {
                return true;
            }

            return false;
        }
    }
}