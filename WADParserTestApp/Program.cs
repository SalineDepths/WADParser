using System;
using System.Runtime.Intrinsics;
using WADParser;

namespace WADParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WADParserObject parser = new WADParserObject();
            FileInfo fileInfo = new FileInfo(Console.ReadLine());

            FileOpResult result = parser.Open(fileInfo);
            CheckIndices(parser);

            List<LumpEntry> searchResults = parser.FindLumps("MAPINFO");
            List<LumpEntry> searchResults2 = parser.FindLumps("MAPINFO\0\0\0\0");
            string checkName = searchResults[0].Name;

            searchResults = parser.FindLumps("TEXTMAP");
            ZdoomTextmap textmap = new ZdoomTextmap(searchResults[0].Data);
            searchResults[0].Data = textmap.WriteBytes();
            result = parser.Write(Console.ReadLine());

            LumpEntry first = parser.GetLumpAt(0);
            LumpEntry last = parser.GetLumpAt(parser.LumpCount - 1);

            LumpEntry test = new LumpEntry("TEST", "THIS IS A TEST");
            parser.InsertLumpAt(test, 0);
            parser.InsertLumpAt("TEST", System.Text.Encoding.Default.GetBytes("THIS IS A TEST 2"), parser.LumpCount);
            parser.InsertLumpAt("TEST", System.Text.Encoding.Default.GetBytes("THIS IS A TEST 3"), parser.LumpCount);
            CheckIndices(parser);

            parser.RemoveLumpAt(parser.LumpCount - 1);
            CheckIndices(parser);

            List<LumpEntry> searchResults3 = parser.FindLumps("TEST");
            foreach (LumpEntry entry in searchResults3)
            {
                entry.Name = "TESTPASS";
            }

            parser.InsertLumpAt("TEST", "THIS IS ANOTHER TEST", parser.LumpCount);
            parser.MoveLumpTo(parser.LumpCount - 1, 3);
            parser.MoveLumpTo(0, parser.LumpCount);
            parser.MoveLumpTo(parser.LumpCount - 1, parser.LumpCount);
            parser.MoveLumpTo(parser.LumpCount - 2, 1);
            CheckIndices(parser);

            result = parser.Write(Console.ReadLine());

            LumpEntry loadEntryTest = WADParserObject.OpenLump(Console.ReadLine(), "TESTLUMP");
            WADParserObject.WriteLump(loadEntryTest, Console.ReadLine());
        }

        static void CheckIndices(WADParserObject parser)
        {
            for (int i = 0; i < parser.LumpCount; i++)
            {
                if (parser.GetLumpAt(i).Index != i)
                {
                    Console.WriteLine("Lump indices misaligned - lump at index " + i + "displayed index " + parser.GetLumpAt(i).Index);
                }
            }
        }
    }
}