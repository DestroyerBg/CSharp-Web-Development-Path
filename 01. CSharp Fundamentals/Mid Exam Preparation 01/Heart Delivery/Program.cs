List<int> neighborhood = Console
    .ReadLine()
    .Split("@")
    .Select(int.Parse)
    .ToList();
string input = string.Empty;
int cupidCurrStep = 0;

while ((input = Console.ReadLine()) != "Love!")
{
    List<string> arguments = input.Split().ToList();
    int cupidStep = int.Parse(arguments[1]);
    cupidCurrStep += cupidStep;
    if (cupidCurrStep > neighborhood.Count-1 )
    {
        cupidCurrStep = 0;
    }

    if (neighborhood[cupidCurrStep] > 0)
    {
        neighborhood[cupidCurrStep] -= 2;
        if (neighborhood[cupidCurrStep] == 0)
        {
            
            Console.WriteLine($"Place {cupidCurrStep} has Valentine's day.");
        }

    }
    else if (neighborhood[cupidCurrStep] == 0)
    {
        
        Console.WriteLine($"Place {cupidCurrStep} already had Valentine's day.");
    }



}

Console.WriteLine($"Cupid's last position was {cupidCurrStep}.");
bool isfailed = false;
int failsCount = 0;
for (int i = 0; i < neighborhood.Count; i++)
{

    if (neighborhood[i] > 0)
    {
        isfailed = true;
        failsCount++;
    }
}

if (isfailed == true)
{
    Console.WriteLine($"Cupid has failed {failsCount} places.");
}
else if (isfailed == false)
{
    Console.WriteLine("Mission was successful.");
}