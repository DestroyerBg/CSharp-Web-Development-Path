using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log4ULibrary.ReportLevels;

namespace Log4ULibrary.Models
{
    public class Message
    {
        public Message(string createdTime, string text, ReportLevelState levelState)
        {
            CreatedTime = createdTime;
            Text = text;
            LevelState = levelState;
        }
        public string CreatedTime { get; private set; }
        public string Text { get; private set; }
        public ReportLevelState LevelState { get; private set; }
    }
}
