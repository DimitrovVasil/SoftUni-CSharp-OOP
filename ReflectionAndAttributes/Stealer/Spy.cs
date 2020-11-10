using System;
using System.Collections.Generic;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string ClassName { get; set; }
        public string[] Array { get; set; }
        public void StealFieldInfo(string className, params string[] strings)
        {
            
            ClassName = className.GetType();
            Array = strings;
        }
    }
}
