using CommandPattern.Core.Contracts;
using System.Linq;
using System;
using System.Reflection;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] splitInfo = args.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            string commandName = splitInfo[0].ToLower(); // Hello or Exit
            string[] arguments = splitInfo.Skip(1).ToArray();

            Type[] types = Assembly.GetCallingAssembly().GetTypes();

            Type commandType = types.FirstOrDefault(t => t.Name.ToLower() == $"{commandName}Command".ToLower()) ;
            ICommand instance = (ICommand)(Activator.CreateInstance(commandType));

            string result = instance.Execute(arguments);

            return result;
        }
    }
}