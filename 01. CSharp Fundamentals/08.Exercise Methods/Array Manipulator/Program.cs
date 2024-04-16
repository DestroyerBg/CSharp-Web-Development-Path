namespace Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrToBeExchanged = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] arguments= input
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string instruction= arguments[0];
                if (instruction== "exchange")
                {
                    int index = int.Parse(arguments[1]);
                   arrToBeExchanged= Exchange(arrToBeExchanged, index);
                }
                else if (instruction== "max")
                {
                    string evenOrOdd= arguments[1];
                    maxEvenOrOdd(arrToBeExchanged, evenOrOdd);
                }
                else if (instruction == "min")
                {
                    string evenOrOdd = arguments[1];
                    minEvenOrOdd(arrToBeExchanged, evenOrOdd);

                }
                else if (instruction == "first")
                {
                    int count = int.Parse(arguments[1]);
                    string evenOrOdd = arguments[2];
                    FirstEvenOrOdd(count, evenOrOdd, arrToBeExchanged);
                }
                else if (instruction == "last")
                {
                    int count = int.Parse(arguments[1]);
                    string evenOrOdd = arguments[2];
                    LastEvenOrOdd(count, evenOrOdd, arrToBeExchanged);
                }
            }
            string result = $"[" + string.Join(", ", arrToBeExchanged) + "]";
            Console.WriteLine(result);
        }

        private static void LastEvenOrOdd(int count, string evenOrOdd, int[] arrToBeExchanged)
        {
            if (count > arrToBeExchanged.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            if (evenOrOdd == "even")
            {
                int[] lastElements= arrToBeExchanged
                    .Where(x=>x%2==0)
                    .TakeLast(count)
                    .ToArray();
                if (lastElements.Length > 0)
                {
                    Console.WriteLine("[" + string.Join(", ", lastElements) + "]");
                }
                else
                {
                    Console.WriteLine("[]");
                }
            }
            else if (evenOrOdd == "odd")
            {
                int[] lastElements = arrToBeExchanged
                    .Where(x => x % 2 == 1)
                    .TakeLast(count)
                    .ToArray();
                if (lastElements.Length > 0)
                {
                    Console.WriteLine("[" + string.Join(", ", lastElements) + "]");
                }
                else
                {
                    Console.WriteLine("[]");
                }
            }
        }

        private static void FirstEvenOrOdd(int count, string evenOrOdd, int[] arrToBeExchanged)
        {
            if (count>arrToBeExchanged.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            if (evenOrOdd=="even")
            {
                int[] firstElements = arrToBeExchanged
                    .Where(x => x % 2 == 0)
                    .Take(count)
                    .ToArray();
                if (firstElements.Length>0)
                {
                    Console.WriteLine("["+ string.Join(", ",firstElements)+"]");
                }
                else
                {
                    Console.WriteLine("[]");
                }
            }
            else if (evenOrOdd=="odd")
            {
                int[] firstElements = arrToBeExchanged
                    .Where(x => x % 2 == 1)
                    .Take(count)
                    .ToArray();
                if (firstElements.Length > 0)
                {
                    Console.WriteLine("[" + string.Join(", ", firstElements) + "]");
                }
                else
                {
                    Console.WriteLine("[]");
                }
            }
        }

        private static void minEvenOrOdd(int[] arrToBeExchanged, string evenOrOdd)
        {
            if (evenOrOdd == "even")
            {
                if (arrToBeExchanged.Any(x => x % 2 == 0))
                {
                    int even = arrToBeExchanged.Where(x => x % 2 == 0).Min();
                    int index = Array.LastIndexOf(arrToBeExchanged, even);
                    Console.WriteLine(index);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
            else if (evenOrOdd == "odd")
            {
                if (arrToBeExchanged.Any(x => x % 2 == 1))
                {
                    int even = arrToBeExchanged.Where(x => x % 2 == 1).Min();
                    int index = Array.LastIndexOf(arrToBeExchanged, even);
                    Console.WriteLine(index);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
        }

        private static void maxEvenOrOdd(int[] arrToBeExchanged, string evenOrOdd)
        {
            if (evenOrOdd== "even")
            {
                if (arrToBeExchanged.Any(x=>x%2==0))
                {
                    int even = arrToBeExchanged.Where(x => x % 2 == 0).Max();
                    int index = Array.LastIndexOf(arrToBeExchanged, even);
                    Console.WriteLine(index);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
            else if (evenOrOdd=="odd")
            {
                if (arrToBeExchanged.Any(x => x % 2 == 1))
                {
                    int even = arrToBeExchanged.Where(x => x % 2 == 1).Max();
                    int index = Array.LastIndexOf(arrToBeExchanged, even);
                    Console.WriteLine(index);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
            
        }


        private static int[] Exchange(int[] arrToBeExchanged, int index)
        {
            if (index<0 || index>arrToBeExchanged.Length-1)
            {
                Console.WriteLine("Invalid index");
                return arrToBeExchanged;
            }

            int[] newArr= new int[arrToBeExchanged.Length];
            int newArrIndex = 0;
            for (int i = index+1; i <= arrToBeExchanged.Length-1; i++)
            {
                newArr[newArrIndex++]= arrToBeExchanged[i];
            }

            for (int i = 0; i <= index; i++)
            {
                newArr[newArrIndex++] = arrToBeExchanged[i];
            }
            return newArr;
        }
    }

    
}