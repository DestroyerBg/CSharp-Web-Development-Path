using _02.CustomStack;

var customStack = new CustomStack();
for (int i = 1; i <= 5; i++)
{
    customStack.Push(i); // Добавяме 5 елемента в стека
}

Console.WriteLine(string.Join(",",customStack)); // проверяваме текущото състояние на стека
Console.WriteLine($"---------------------");
Console.WriteLine(customStack.Pop()); // елемента който беше изваден от стека
Console.WriteLine(string.Join(",", customStack)); // проверяваме текущото състояние на стека
Console.WriteLine($"---------------------");
Console.WriteLine(customStack.Peek()); // пийкваме без да вадим този път елемента
Console.WriteLine(string.Join(",", customStack));
