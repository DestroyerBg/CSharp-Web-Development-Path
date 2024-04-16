using _03.ShoppingSpree;

var persons = new List<Person>();
var productPrices = new Dictionary<string, decimal>();
try
{
    string[] people = Console.ReadLine()
        .Split(";", StringSplitOptions.RemoveEmptyEntries);
    for (int i = 0; i < people.Length; i++)
    {
        string[] currPerson = people[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
        string name = currPerson[0];
        decimal money = decimal.Parse(currPerson[1]);
        Person person = new Person(name, money);
        persons.Add(person);
    }
    string[] products = Console.ReadLine()
        .Split(";", StringSplitOptions.RemoveEmptyEntries);
    for (int i = 0; i < products.Length; i++)
    {
        string[] currProduct = products[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
        string productName = currProduct[0];
        decimal price = decimal.Parse(currProduct[1]);
        productPrices.Add(productName, price);
    }


}
catch (Exception error)
{
    Console.WriteLine(error.Message);
    Environment.Exit(0);
}
string input = string.Empty;
while ((input = Console.ReadLine()) != "END")
{
    string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string personName = data[0];
    string productName = data[1];
    var product = new Product(productName, productPrices.First(p => p.Key == productName).Value);
    Console.WriteLine(persons.Find(p => p.Name == personName).BuyProduct(product));
}

foreach (var person in persons)
{
    Console.WriteLine(person.ToString());
}