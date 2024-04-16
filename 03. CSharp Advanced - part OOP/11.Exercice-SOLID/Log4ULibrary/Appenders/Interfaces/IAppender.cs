using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4ULibrary.Appenders.Interfaces
{
    public interface IAppender
    {
        void Append(string message);
    }
}
