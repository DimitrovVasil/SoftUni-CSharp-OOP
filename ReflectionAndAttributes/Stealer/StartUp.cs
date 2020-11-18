using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Stealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();

            //var result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            //var result = spy.AnalyzeAcessModifiers("Stealer.Hacker");
            var result = spy.RevealPrivateMethods("Stealer.Hacker");
            Console.WriteLine(result);
           
        }
    }
}
