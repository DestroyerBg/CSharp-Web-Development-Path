double distanceInMeters=double.Parse(Console.ReadLine());
double distanceInKilometres = distanceInMeters / 1000;
Console.WriteLine($"{distanceInKilometres:f2}");