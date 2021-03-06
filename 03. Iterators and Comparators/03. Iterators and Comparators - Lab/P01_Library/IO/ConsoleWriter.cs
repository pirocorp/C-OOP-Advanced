﻿namespace P01_Library.IO
{
    using System;
    using Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string content)
        {
            Console.WriteLine(content);
        }

        public void WriteLine(object content)
        {
            Console.WriteLine(content.ToString());
        }
    }
}