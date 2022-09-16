using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WADParser
{
    public class LumpEntry
    {
        public LumpEntry() { }
        public LumpEntry(string nameIn, byte[] dataIn)
        {
            Name = nameIn;
            Data = dataIn;
        }

        public string Name 
        {
            get { return internalName; }
            set
            {
                internalName = value;

                for (int i = 8 - internalName.Length; i > 0; i--)
                {
                    internalName += '\0';
                }

                internalName = internalName.Substring(0, 8);
            }
        }

        public byte[] Data;

        string internalName;
    }
}
