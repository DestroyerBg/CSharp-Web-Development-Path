using System;
using INStock.Engine.Contracts;

namespace INStock
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine.Engine();
            engine.Run();
        }
    }
}
