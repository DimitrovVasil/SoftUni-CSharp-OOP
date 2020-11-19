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

        public string AnalyzeAcessModifiers(string className)
        {
            Type type = Type.GetType(className);
            var instance = Activator.CreateInstance(type);

            //find fields
            FieldInfo[] fields = type.GetFields (
                BindingFlags.NonPublic 
                | BindingFlags.Public 
                | BindingFlags.Static
                | BindingFlags.Instance);

            //find methods 
            var methods = type.GetMethods(
                BindingFlags.NonPublic
                | BindingFlags.Public

                | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            foreach (var field in fields)
            {
                if (!field.IsPrivate)
                {
                    sb.AppendLine($"{field.Name} must be private!");
                }
            }

            foreach (var method in methods)
            {

                if (method.Name.StartsWith("get"))
                {
                    if (method.IsPrivate)
                    {
                        sb.AppendLine($"{method.Name} must be public!");
                    }
                }
            }

            foreach (var method in methods)
            {           
                if (method.Name.StartsWith("set"))
                {
                    if (!method.IsPrivate)
                    {
                        sb.AppendLine($"{method.Name} must be private!");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);

            //find base class
            var baseClass = type.BaseType;
            //find methods
            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {baseClass.Name}");

            foreach (var method in methods)
            {
                sb.AppendLine($"{method.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealAllMethods(string className)
        {
            Type type = Type.GetType(className);

            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            foreach (var method in methods)
            {
                if (method.Name.StartsWith("get"))
                {
                    sb.AppendLine($"{method.Name} will return {method.ReturnType}");
                }       
            }

            foreach (var method in methods)
            {
                if (method.Name.StartsWith("set"))
                {
                    sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}