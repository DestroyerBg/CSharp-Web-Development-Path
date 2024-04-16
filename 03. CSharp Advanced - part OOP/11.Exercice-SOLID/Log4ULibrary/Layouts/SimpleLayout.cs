using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log4ULibrary.Layouts.Interfaces;

namespace Log4ULibrary.Layouts
{
    public class SimpleLayout : ILayout
    {
        private string defaultFormat = "{0} - {1} - {2}";
        public string Format => defaultFormat;
    }
}
