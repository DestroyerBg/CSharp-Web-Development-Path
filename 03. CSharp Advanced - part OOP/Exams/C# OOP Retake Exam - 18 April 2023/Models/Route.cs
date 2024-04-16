using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models.Contracts;

namespace EDriveRent.Models
{
    public class Route : IRoute
    {
        private string startPoint;
        private string endPoint;
        private double lenght;

        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Length = length;
            RouteId = routeId;
            IsLocked = false;
        }
        public string StartPoint
        {
            get => startPoint;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"StartPoint cannot be null or whitespace!");
                }
                startPoint = value;
            }
        }

        public string EndPoint
        {
            get => endPoint;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Endpoint cannot be null or whitespace!");
                }
                endPoint = value;
            }
        }

        public double Length
        {
            get => lenght;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Length cannot be less than 1 kilometer.");
                }
                lenght = value;
            }
        }
        public int RouteId { get; private set; }
        public bool IsLocked { get; private set; }
        public void LockRoute()
        {
            IsLocked = true;
        }
    }
}
