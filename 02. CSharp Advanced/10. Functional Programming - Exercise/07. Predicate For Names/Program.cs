Func<string, int,bool> predicateForNames = (name, requireLenght) =>
{
    return name.Length <= requireLenght;
};
int lenght = int.Parse(Console.ReadLine());
string[] names = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
for (int i = 0; i < names.Length; i++)
{
    if (predicateForNames(names[i],lenght))
    {
        Console.WriteLine(names[i]);
    }
}