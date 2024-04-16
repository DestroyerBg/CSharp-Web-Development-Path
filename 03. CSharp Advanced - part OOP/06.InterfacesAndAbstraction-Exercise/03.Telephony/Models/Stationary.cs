using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.Telephony.IO;
using _03.Telephony.IO.Interfaces;

namespace _03.Telephony.Models
{
    internal class Stationary : ICaller
    {
        public void Call(string number)
        {
            IWriter writer = new Writer();
            if (ISValidNumber(number))
            {
                if (number.Length == 10)
                {
                    writer.WriteLine($"Calling... {number}");
                }
                else if (number.Length == 7)
                {
                    writer.WriteLine($"Dialing... {number}");
                }
            }
            else
            {
                writer.WriteLine($"Invalid number!");
            }

        }
        private bool ISValidNumber(string number)
        {
            if (number.Any(n => char.IsDigit(n) == false))
            {
                return false;
            }

            return true;
        }
    }
}
