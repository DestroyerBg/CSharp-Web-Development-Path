using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const double DefaultCalories = 2;
        private const int MinGrams = 1;
        private const int MaxGrams = 200;
        private Dictionary<string, double> flourTechniquesCalories;
        private Dictionary<string, double> bakingTechniquesCalories;
        private string flourTechnique;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourTechnique, string bakingTechnique,double weight)
        {
            flourTechniquesCalories = new Dictionary<string, double>()
            {
                {"white",1.5},
                {"wholegrain",1.0}
            };
            bakingTechniquesCalories = new Dictionary<string, double>()
            {
                {"crispy",0.9},
                {"chewy",1.1},
                {"homemade",1.0}
            };
            Weight = weight;
            FlourTechnique = flourTechnique;
            BakingTechnique = bakingTechnique;
        }

        public string FlourTechnique
        {
            get => flourTechnique;

            private set
            {
                if (!flourTechniquesCalories.ContainsKey(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");
                }
                flourTechnique = value;
            }
        }

        public string BakingTechnique { 
            get => bakingTechnique;
            private set
            {
                if (!bakingTechniquesCalories.ContainsKey(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");
                }
                bakingTechnique = value;
            }

        }

        public double Weight
        {
            get => weight;
            private set
            {
                if (value < MinGrams || value > MaxGrams)
                {
                    throw new Exception($"Dough weight should be in the range [1..200].");
                }
                weight = value;
            }

        }

        public double Calories
        {
            get
            {
                double flourTypeCalories = flourTechniquesCalories[flourTechnique.ToLower()];
                double bakeTypeCalories = bakingTechniquesCalories[bakingTechnique.ToLower()];
                return DefaultCalories * Weight * flourTypeCalories * bakeTypeCalories;
            }
        }

    }
}
