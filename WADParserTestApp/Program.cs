using System;
using WADParser;

namespace WADParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WADParserObject parser = new WADParserObject();
            parser.Open(Console.ReadLine());

            List<LumpEntry> searchResults = parser.FindLumps("MAPINFO");
            List<LumpEntry> searchResults2 = parser.FindLumps("MAPINFO\0\0\0\0");

            LumpEntry first = parser.GetLumpAt(0);
            LumpEntry last = parser.GetLumpAt(parser.LumpCount - 1);

            LumpEntry test = new LumpEntry("TEST", "THIS IS A TEST");
            parser.InsertLumpAt(test, 0);
            parser.InsertLumpAt("TEST", System.Text.Encoding.Default.GetBytes("THIS IS A TEST"), parser.LumpCount);
            parser.InsertLumpAt("TEST", System.Text.Encoding.Default.GetBytes("THIS IS A TEST"), parser.LumpCount);

            parser.RemoveLumpAt(parser.LumpCount - 1);

            List<LumpEntry> searchResults3 = parser.FindLumps("TEST");
            foreach (LumpEntry entry in searchResults3)
            {
                entry.Name = "TESTPASS";
            }

            parser.InsertLumpAt("TEST", "THIS IS ANOTHER TEST", parser.LumpCount);
            parser.Write(Console.ReadLine());
        }
    }
}