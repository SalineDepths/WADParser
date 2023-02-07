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
        public LumpEntry(string nameIn, string dataIn)
        {
            Name = nameIn;
            Data = System.Text.Encoding.Default.GetBytes(dataIn);
        }

        public string Name 
        {
            get { return internalName.Replace("\0", ""); }
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

        /// <summary>
        /// Returns the null terminator-padded version of this lump's name
        /// </summary>
        public string GetDoomFriendlyName() { return internalName; }

        public byte[] Data;
        public int Index { get; internal set; } = -1;

        string internalName;
    }
}
