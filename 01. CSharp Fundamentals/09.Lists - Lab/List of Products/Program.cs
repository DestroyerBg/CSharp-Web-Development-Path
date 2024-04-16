int n = int.Parse(Console.ReadLine());
List<string> product = new List<string>();
for (int i = 0; i < n; i++)
{
    product.Add(Console.ReadLine());

}
product.Sort();
for (int i = 0; i < product.Count; i++)
{
    Console.WriteLine($"{i+1}.{product[i]}");
}


