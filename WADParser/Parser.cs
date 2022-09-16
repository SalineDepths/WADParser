namespace WADParser
{
    public class Parser
    {
        const int WADHEADER_SIZE = 12;
        const int DIRECTORYENTRY_SIZE = 16;

        List<LumpEntry> m_entries = new List<LumpEntry>();
        string m_wadType = "";

        public int LumpCount { get { return m_entries.Count; } }

        /// <summary>
        /// Opens a given WAD file
        /// </summary>
        /// <param name="fileName">The file to open</param>
        /// <returns>If the load was successful</returns>
        public bool Open(string fileName)
        {
            if (fileName == null || !File.Exists(fileName))
                return false;

            using (BinaryReader reader = new BinaryReader(File.OpenRead(fileName)))
            {
                if (reader.BaseStream.Length < 12)
                    return false; //Too short to contain a header, so cannot just be an empty WAD

                int lumpCount;
                int dirPos;

                m_wadType = System.Text.Encoding.Default.GetString(reader.ReadBytes(4));
                if (m_wadType != "IWAD" && m_wadType != "PWAD")
                    return false; //All WADs should have one or the other

                lumpCount = reader.ReadInt32();
                dirPos = reader.ReadInt32();

                reader.BaseStream.Position = dirPos;

                int lumpPos;
                int size;
                string name;
                byte[] contents;

                BinaryReader lumpReader = new BinaryReader(File.OpenRead(fileName));

                for (int i = 0; i < lumpCount; i++)
                {
                    lumpPos = reader.ReadInt32();
                    size = reader.ReadInt32();
                    name = System.Text.Encoding.Default.GetString(reader.ReadBytes(8));

                    lumpReader.BaseStream.Position = lumpPos;
                    contents = lumpReader.ReadBytes(size);
                    m_entries.Add(new LumpEntry(name, contents));
                }
            }

            return true;
        }

        /// <summary>
        /// Saves to fileName.  Destroys and recreates the file if it already exists.
        /// </summary>
        /// <param name="fileName">The file to write to</param>
        public void Write(string fileName)
        {
            if (fileName == null || fileName.Length == 0)
                return;

            if (File.Exists(fileName))
                File.Delete(fileName);

            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(fileName)))
            {
                //HEADER
                writer.Write(m_wadType.ToCharArray());
                writer.Write(m_entries.Count);
                writer.Write(WADHEADER_SIZE);

                //DIRECTORY
                int directorySize = m_entries.Count * DIRECTORYENTRY_SIZE;
                int currPos = WADHEADER_SIZE + directorySize;

                for (int i = 0; i < m_entries.Count; ++i)
                {
                    writer.Write(currPos);
                    writer.Write(m_entries[i].Data.Length);
                    writer.Write(m_entries[i].Name.ToCharArray());

                    currPos += m_entries[i].Data.Length;
                }

                //LUMPS
                for (int i = 0; i < m_entries.Count; ++i)
                {
                    writer.Write(m_entries[i].Data);
                }
            }
        }
    }
}