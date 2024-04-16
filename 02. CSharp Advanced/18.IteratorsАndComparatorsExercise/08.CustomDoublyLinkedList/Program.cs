using System.Threading.Channels;
using CustomDoublyLinkedList;

var newList = new DoublyLinkedList();

for (int i = 5; i >= 1; i--)
{
    newList.AddFirst(i); //Добавяме 1,2,3,4,5
}

newList.ForEach(x=>Console.Write($"{x} ")); // Печатаме
Console.WriteLine();
Console.WriteLine($"-------------------"); 
int last = newList.RemoveLast();
Console.WriteLine(last); // Изтриваме последния елемент от листа и го печатаме
Console.WriteLine($"-------------------");
int first = newList.RemoveFirst();
Console.WriteLine(first); // Изтриваме първия елемент от листа и го печатаме
Console.WriteLine($"-------------------");
int count =  newList.Count; 
Console.WriteLine(count);  // Колко числа имаме в листа до момента?
Console.WriteLine($"-------------------");
int[] toArrayTest = newList.ToArray();
Console.WriteLine(string.Join(" ",toArrayTest)); // Правим масив от листа и го печатаме със StringJoin