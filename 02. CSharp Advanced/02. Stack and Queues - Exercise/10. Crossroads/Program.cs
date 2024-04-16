using System.Text;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            string input = string.Empty;
            var traffic = new Queue<string>();
            int carsPassed = 0;
            bool IsCrashHappened = false;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    traffic.Enqueue(input);
                    continue;
                }
                int currGreenLight = greenLightSeconds;



                while (traffic.Count > 0 && currGreenLight > 0)
                {
                    string currCar = traffic.Dequeue();
                    if (currGreenLight - currCar.Length >= 0)
                    {
                        currGreenLight -= currCar.Length;
                        carsPassed++;
                    }
                    else if (currGreenLight+freeWindow - currCar.Length >= 0)
                    {
                        currGreenLight-=currCar.Length;
                        carsPassed++;
                    }
                    else
                    {
                        char carWasHitAt = currCar[currGreenLight+freeWindow];
                        IsCrashHappened=true;
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currCar} was hit at {carWasHitAt}.");
                        break;
                    }

                }

                if (IsCrashHappened == true)
                {
                    break;
                }

            }
            if (IsCrashHappened == false)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
            }
        }
    }

    }


