using _14._Create_Custom_Data_Structures;

var customList = new CustomList();

for (int i = 1; i <= 20; i++)
{
    customList.Add(i); // Добавяме 20 елемента към листа
}

Console.WriteLine(string.Join(",",customList)); // Печатаме елементите от листа до момента

customList.RemoveAt(6); // Трием 6-цата
//customList.RemoveAt(333); Exception
Console.WriteLine($"-------------------");
Console.WriteLine(string.Join(",", customList)); // Печатаме елементите от листа до момента

customList.Insert(8, 333); // Добавяме на 8-ми индекс елемент 333
Console.WriteLine($"-------------------");
Console.WriteLine(string.Join(",", customList)); // Печатаме елементите от листа до момента
//customList.Insert(333,333); Exception
Console.WriteLine($"-------------------");
Console.WriteLine(customList.Constains(333)); // Проверка дали имаме 333- /true
var swappedList = new CustomList();
swappedList.Add(1);
swappedList.Add(2);
swappedList.Swap(1,0); // правим нов лист и разменяме местата на елементите
Console.WriteLine($"-------------------");
Console.WriteLine(string.Join(",", swappedList)); //печатаме разменения лист
customList.Reverse();// Обръщаме листа наобратно
Console.WriteLine($"-------------------");
Console.WriteLine(string.Join(",", customList)); // печатаме листа вече отзад напред