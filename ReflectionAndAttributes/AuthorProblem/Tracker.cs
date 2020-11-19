using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        
        public static void PrintMethodsByAuthor()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Type type = typeof(StartUp);
            var attributes = assembly.GetCustomAttributes();

            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
                {
                    var methodAttributes = method.GetCustomAttributes();
                    Attribute targetAttr = methodAttributes.FirstOrDefault(a => a.GetType() == typeof(AuthorAttribute));
                    var finalAttr = targetAttr as AuthorAttribute;
                    Console.WriteLine($"{method.Name} is written by {finalAttr.Name}");
                }

            }

        }
    }
}
