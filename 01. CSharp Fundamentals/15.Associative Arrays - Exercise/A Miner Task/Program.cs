using System.Formats.Asn1;

namespace A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=string.Empty;
            var miner = new Dictionary<string, uint>();
            
           
            while ((input = Console.ReadLine()) != "stop")
            {
                if (!miner.ContainsKey(input))
                {
                    miner.Add(input, 0);
                }
                uint Ore=uint.Parse(Console.ReadLine());
                miner[input] += Ore;

            }

            foreach (var pair in miner)
            {
                string ore=pair.Key;
                uint value=pair.Value;
                Console.WriteLine($"{ore} -> {value}");
            }
        }
    }
}