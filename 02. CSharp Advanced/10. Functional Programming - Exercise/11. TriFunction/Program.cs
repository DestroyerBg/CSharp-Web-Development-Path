using System.Threading.Channels;

int number = int.Parse(Console.ReadLine());
string[] names = Console.ReadLine().Split().ToArray();
Func<string[], int, string> calculateSum = (names, number) =>
{
    int sum = 0;
    for (int i = 0; i < names.Length; i++)
    {
        string currName = names[i];
        for (int j = 0; j < currName.Length; j++)
        {
            sum += currName[j];
            if (sum >= number)
            {
                return currName;
            }
        }

        sum = 0;
    }


    return default;
};
Console.WriteLine(calculateSum(names, number));