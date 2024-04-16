Console.Write("Length: ");
double lenght = double.Parse(Console.ReadLine());
Console.Write("Width: ");
double width = double.Parse(Console.ReadLine());
Console.Write("Height: ");
double height = double.Parse(Console.ReadLine());
double s = lenght * width;
double volume = (s * height) / 3;
Console.Write($"Pyramid Volume: {volume:f2}");