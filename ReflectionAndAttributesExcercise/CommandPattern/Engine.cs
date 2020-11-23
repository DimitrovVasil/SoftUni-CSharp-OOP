﻿using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                string commandResult = commandInterpreter.Read(input);
                Console.WriteLine(commandResult);
            }
        }
    }
}