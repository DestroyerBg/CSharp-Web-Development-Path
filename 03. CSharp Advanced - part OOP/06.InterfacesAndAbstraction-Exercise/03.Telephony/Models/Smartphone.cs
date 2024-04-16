using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.Telephony.IO;
using _03.Telephony.IO.Interfaces;

namespace _03.Telephony.Models
{
    public class Smartphone : IBrowser, ICaller
    {
        private IWriter writer = new Writer();
        public void Call(string number)
        {
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
        public void Browse(string url)
        {
            if (ISValidURL(url))
            {
                writer.WriteLine($"Browsing: {url}!");
            }
            else
            {
                writer.WriteLine($"Invalid URL!");
            }
        }

        private bool ISValidNumber(string number)
        {
            if (number.Any(n=>char.IsDigit(n) == false))
            {
                return false;
            }

            return true;
        }
        private bool ISValidURL(string url)
        {
            if (url.Any(n => char.IsDigit(n) == true))
            {
                return false;
            }

            return true;
        }
    }
}
