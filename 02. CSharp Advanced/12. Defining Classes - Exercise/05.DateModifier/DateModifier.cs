using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public static class DateModifier
    {
        public static int CalculateDifference(string date1, string date2)
        {
            var firstDate = DateTime.Parse(date1);
            var secondDate = DateTime.Parse(date2);
           TimeSpan difference = firstDate - secondDate;
           return Math.Abs(difference.Days);
        }
    }
}
