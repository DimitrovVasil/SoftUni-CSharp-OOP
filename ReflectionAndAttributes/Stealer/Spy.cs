using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Stealer
{
    public class Spy
    {
        public string ClassName { get; set; }
        public string[] Array { get; set; }
        public string StealFieldInfo(string className, params string[] strings)
        {

            Type classNeeded = Type.GetType(className);
           
            FieldInfo[] fields = classNeeded.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();

            Object instance = Activator.CreateInstance(classNeeded, new object[] { });
            var fieldsNeeded = fields.Where( f => strings.Contains(f.Name)).ToList();
           
            sb.AppendLine($"Class under investigation: {className}");
           
            foreach (var field in fieldsNeeded)
            {
               sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            var result = sb.ToString().Trim();

            return result;

        }
    }
}
