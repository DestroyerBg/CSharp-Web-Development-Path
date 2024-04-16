using System.Text;

namespace Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string variableType = Console.ReadLine();
            if (variableType == "int")
            {
                double numberOne = double.Parse(Console.ReadLine());
                double numberTwo = double.Parse(Console.ReadLine());
                Compare(numberOne, numberTwo);
            }
            else if (variableType == "string")
            {
                string stringOne = Console.ReadLine();
                string stringTwo = Console.ReadLine();
                Compare(stringOne, stringTwo);
            }
            else if (variableType == "char")
            {
                char charOne = char.Parse(Console.ReadLine());
                char charTwo = char.Parse(Console.ReadLine());
                Compare(charOne, charTwo);
            }
           

        }
        static void Compare(double numberOne, double numberTwo)
        {
            if (numberOne > numberTwo)
            {
                Console.WriteLine(numberOne);
            }
            else if (numberTwo > numberOne)
            {
                Console.WriteLine(numberTwo);
            }
            else if (numberOne == numberTwo)
            {
                Console.WriteLine(numberOne);
            }

        }
        static void Compare(string stringOne, string stringTwo)
        {
            if (string.Compare(stringOne,stringTwo)==1)
            {
                Console.WriteLine(stringOne);
            }
            else
            {
                Console.WriteLine(stringTwo);
            }
            
            




        }
        static void Compare(char charOne, char charTwo)
        {
            int charOneValue = (int)charOne;
            int charTwoValue = (int)charTwo;
            if (charOneValue>charTwoValue)
            {
                Console.WriteLine(charOne);
            }
            else if (charTwoValue>charOneValue)
            {
                Console.WriteLine(charTwo);
            }
            else if (charOneValue==charTwoValue)
            {
                Console.WriteLine(charTwo);
            }
        
        }

    }
}