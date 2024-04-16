using _03.CustomQueue;

var customQueue = new CustomQueue();
for (int i = 1; i <= 5; i++)
{
    customQueue.Enqueue(i); // Добавяме 5 елемента в опашката
}

Console.WriteLine(string.Join(",",customQueue)); // печатаме опашката 
Console.WriteLine($"---------------");
Console.WriteLine(customQueue.Dequeue()); // вадим първи елемент от опашката и после я принтираме в текущото й състояние
Console.WriteLine($"---------------");
Console.WriteLine(string.Join(",", customQueue));
Console.WriteLine($"---------------");
Console.WriteLine(customQueue.Peek()); // тук само пийкваме без да вадим и после принтираме
Console.WriteLine(string.Join(",", customQueue));
Console.WriteLine($"---------------");
