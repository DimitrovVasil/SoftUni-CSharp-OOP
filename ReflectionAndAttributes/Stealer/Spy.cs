using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] strings)
        {
            Type investigatedClass = Type.GetType(className);
            var instance = Activator.CreateInstance(investigatedClass);
            FieldInfo[] fields = investigatedClass.GetFields(BindingFlags.NonPublic | BindingFlags.Instance |BindingFlags.Static | BindingFlags.Public);           

            StringBuilder sb = new StringBuilder($"Class under investigation: {instance.GetType()}" + Environment.NewLine);
            
            foreach (var field in fields)
            {
                if (strings.Contains(field.Name))
                {
                    sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
                }    
            }

            return sb.ToString().TrimEnd();
        }
    }
}