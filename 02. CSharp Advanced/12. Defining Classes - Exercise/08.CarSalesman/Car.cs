using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CarSalesman
{
    public class Car
    {
        public Car()
        {
            Weight = default;
            Color = default;
        }

        public Car(string model, Engine engine) :this()
        {
            Model = model;
            Engine = engine;
        }
        public Car(string model, Engine engine, int weight) : this()
        {
            Model = model;
            Engine = engine;
            Weight = weight;
        }
        public Car(string model, Engine engine, string color) : this()
        {
            Model = model;
            Engine = engine;
            Color = color;
        }
        public Car(string model, Engine engine, string color, int weight)
        {
            Model = model;
            Engine = engine;
            Color = color;
            Weight = weight;
        }


        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{Model}:");
            result.AppendLine($"{" ",2}{Engine.Model}:");
            result.AppendLine($"{" ",4}Power: {Engine.Power}");
            if (Engine.Displacement != default)
            {
                result.AppendLine($"{" ",4}Displacement: {Engine.Displacement}");
            }
            else
            {
                result.AppendLine($"{" ",4}Displacement: n/a");
            }
            if (Engine.Efficency != default)
            {
                result.AppendLine($"{" ",4}Efficiency: {Engine.Efficency}");
            }
            else
            {
                result.AppendLine($"{" ",4}Efficiency: n/a");
            }
            if (Weight != default)
            {
                result.AppendLine($"{" ",2}Weight: {Weight}");
            }
            else
            {
                result.AppendLine($"{" ",2}Weight: n/a");
            }
            if (Color != default)
            {
                result.AppendLine($"{" ",2}Color: {Color}");
            }
            else
            {
                result.AppendLine($"{" ",2}Color: n/a");
            }
            return result.ToString().TrimEnd();

        }
    }
}
