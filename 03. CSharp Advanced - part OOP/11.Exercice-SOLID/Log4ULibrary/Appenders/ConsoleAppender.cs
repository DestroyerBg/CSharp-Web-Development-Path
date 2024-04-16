using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log4ULibrary.Appenders.Interfaces;
using Log4ULibrary.Layouts.Interfaces;
using Log4ULibrary.ReportLevels;

namespace Log4ULibrary.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ReportLevelState reportLevel)
        {
            Layout = layout;
            ReportLevel = reportLevel;
        }
        public ILayout Layout { get; private set; }
        public ReportLevelState ReportLevel { get; private set; }

        public void Append(string message)
        {
            Console.WriteLine();
        }
    }
}
