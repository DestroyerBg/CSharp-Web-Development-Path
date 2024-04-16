using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] arguments = args.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string commandName = arguments[0];
            string[] instructions = arguments.Skip(1).ToArray();
            Type type = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(c=>c.Name==$"{commandName}Command");
            if (type == null)
            {
                throw new InvalidOperationException("Command not found");
            }
            ICommand instance = Activator.CreateInstance(type) as ICommand;
            string result = instance.Execute(instructions);
            return result;
        }
    }
}
