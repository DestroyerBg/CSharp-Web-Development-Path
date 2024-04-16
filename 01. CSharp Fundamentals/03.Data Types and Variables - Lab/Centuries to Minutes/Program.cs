int century = int.Parse(Console.ReadLine());
int centiriesToYears = century * 100;
double yearsToDays = (double)365.2422 * (double)centiriesToYears;

int hours = 24 * (int)yearsToDays;
int minutes = 60 * hours;
Console.WriteLine($"{century} centuries = {centiriesToYears} years = {(int)yearsToDays} days = {hours} hours = {minutes} minutes");