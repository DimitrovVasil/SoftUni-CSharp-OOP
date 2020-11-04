using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var randomList = new RandomList();

            randomList.Add("Gosho");
            randomList.Add("Pesho");
            randomList.Add("Tosho");

            Console.WriteLine(randomList.RandomString());
        }
    }
}
