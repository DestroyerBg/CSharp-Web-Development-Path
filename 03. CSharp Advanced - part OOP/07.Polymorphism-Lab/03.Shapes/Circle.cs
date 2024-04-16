﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }
        public double Radius
        {
            get => radius;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                radius = value;
            }
            
        }
        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override string Draw()
        {
            return base.Draw() + $" {GetType().Name}";
        }
    }
}
