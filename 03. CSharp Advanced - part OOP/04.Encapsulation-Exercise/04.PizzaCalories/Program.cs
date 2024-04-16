using _04.PizzaCalories;

try
{
    string[] pizzaData = Console.ReadLine().Split();
    string pizzaName = pizzaData[1];
    var pizza = new Pizza(pizzaName);
    string[] doughData = Console.ReadLine().Split();
    string flourTechnique = doughData[1];
    string bakingTechnique = doughData[2];
    double weight = double.Parse(doughData[3]);
    var dough = new Dough(flourTechnique, bakingTechnique, weight);
    pizza.Dough = dough;
    string input = string.Empty;
    while ((input = Console.ReadLine()) != "END")
    {
        string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string topingType = data[1];
        double topingWeight = double.Parse(data[2]);
        var toping = new Topping(topingType,topingWeight);
        pizza.AddToping(toping);
    }

    Console.WriteLine(pizza);

}
catch (Exception error)
{
    Console.WriteLine(error.Message);
}
