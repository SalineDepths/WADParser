using System;
using WADParser;

namespace WADParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            parser.Open(Console.ReadLine());

            parser.Write(Console.ReadLine());
        }
    }
}