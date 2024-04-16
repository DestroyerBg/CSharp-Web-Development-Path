using System.Diagnostics;

string input = string.Empty;
var shopStorage = new SortedDictionary<string, List<Product>>();
while ((input = Console.ReadLine()) != "Revision")
{
    string[] data = input
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    string shopName = data[0];
    string product = data[1];
    double price = double.Parse(data[2]);
    Product newProduct = new Product(product,price);
    if (!shopStorage.ContainsKey(shopName))
    {
        shopStorage.Add(shopName, new List<Product>());
    }
    shopStorage[shopName].Add(newProduct);
}


foreach (var entry in shopStorage)
{
    Console.WriteLine($"{entry.Key}->");
    foreach (var product in entry.Value)
    {
        Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
    }
}
class Product
{
    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; set; }
    public double Price { get; set; }
}

