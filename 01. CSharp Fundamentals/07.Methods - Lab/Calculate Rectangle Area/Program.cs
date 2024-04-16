double width =double.Parse(Console.ReadLine());
double height =double.Parse(Console.ReadLine());
double area= GetAreaOfTriangle(width, height);

static double GetAreaOfTriangle(double width, double height)
{ 
    double area=width*height;
    return area;

}
Console.WriteLine(area);