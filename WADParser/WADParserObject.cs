namespace WADParser
{
    public enum WadTypeEnum
    {
        IWAD,
        PWAD,
        None
    }

    public class WADParserObject
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
            m_entries = new List<LumpEntry>();
            m_wadType = "";

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

            ValidateLumpIndices();
            return true;
        }

        /// <summary>
        /// Saves to fileName.  Destroys and recreates the file if it already exists.
        /// </summary>
        /// <param name="fileName">The file to write to</param>
        public void Write(string fileName)
        {
            if (fileName == null || fileName.Length == 0 || !fileName.ToLower().EndsWith(".wad")
                || (m_wadType != "IWAD" && m_wadType != "PWAD"))
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

        /// <summary>
        /// Sets the WAD type used in the header.  Valid types for saving files are "IWAD" and "PWAD"
        /// Note that this is not meant to be used when loading files.  This is for assembling a WAD from scratch.
        /// </summary>
        /// <param name="newType">The wad type to save as</param>
        public void SetWadType(WadTypeEnum newType)
        {
            switch(newType)
            {
                case WadTypeEnum.IWAD:
                    m_wadType = "IWAD";
                    break;
                case WadTypeEnum.PWAD:
                    m_wadType = "PWAD";
                    break;
                case WadTypeEnum.None:
                default:
                    m_wadType = "";
                    break;
            }
        }

        /// <summary>
        /// Gets a reference to the lump at the given index
        /// </summary>
        /// <param name="index">The index to pull the lump from</param>
        /// <returns>A reference to the lump at index, or null if index is out of bounds</returns>
        public LumpEntry GetLumpAt(int index)
        {
            if (index < LumpCount && index >= 0)
                return m_entries[index];

            return null;
        }

        /// <summary>
        /// Gets a list of references to all lumps matching the given name.
        /// </summary>
        /// <param name="name">The name to search for.  Null terminators are automatically applied for names less than 8 characters long.</param>
        /// <returns>A list of references to lumps that match the search term</returns>
        public List<LumpEntry> FindLumps(string name)
        {
            List<LumpEntry> ret = new List<LumpEntry>();

            if (name == null)
                return ret;

            string searchTerm = name;
            for (int i = 8 - searchTerm.Length; i > 0; --i)
            {
                searchTerm += '\0';
            }

            searchTerm = searchTerm.Substring(0, 8);
            foreach (LumpEntry entry in m_entries)
            {
                if (entry.Name == searchTerm)
                    ret.Add(entry);
            }

            return ret;
        }

        /// <summary>
        /// Constructs and inserts a new lump at index
        /// </summary>
        /// <param name="name">The name of the new lump</param>
        /// <param name="data">The data the new lump contains</param>
        /// <param name="index">The index to insert the lump at</param>
        public void InsertLumpAt(string name, byte[] data, int index)
        {
            InsertLumpAt(new LumpEntry(name, data), index);
        }

        /// <summary>
        /// Constructs and inserts a new lump at index
        /// </summary>
        /// <param name="name">The name of the new lump</param>
        /// <param name="data">The data the new lump contains</param>
        /// <param name="index">The index to insert the lump at</param>
        public void InsertLumpAt(string name, string data, int index)
        {
            InsertLumpAt(new LumpEntry(name, data), index);
        }

        /// <summary>
        /// Inserts the given lump at index
        /// </summary>
        /// <param name="entry">The lump to insert</param>
        /// <param name="index">The index to insert the lump at</param>
        public void InsertLumpAt(LumpEntry entry, int index)
        {
            if (index >= 0 && index <= m_entries.Count)
            {
                m_entries.Insert(index, entry);

                ValidateLumpIndices();
            }
        }

        /// <summary>
        /// Removes the lump at index
        /// </summary>
        /// <param name="index">The index to remove the lump from</param>
        public void RemoveLumpAt(int index)
        {
            if (index >= 0 && index < m_entries.Count)
            {
                m_entries.RemoveAt(index);

                ValidateLumpIndices();
            }
        }

        /// <summary>
        /// Moves the lump at the given index to destinationIndex.
        /// </summary>
        /// <param name="index">The lump to move</param>
        /// <param name="destinationIndex">The index to move the lump to.  Valid range is 0-LumpCount</param>
        public void MoveLumpTo(int index, int destinationIndex)
        {
            if (index < 0 || index >= LumpCount || destinationIndex < 0 || destinationIndex > LumpCount)
                return;

            LumpEntry entry = m_entries[index];
            int newIndex = destinationIndex;

            if (index < destinationIndex)
                newIndex--;

            m_entries.RemoveAt(index);
            m_entries.Insert(newIndex, entry);

            ValidateLumpIndices();
        }

        /// <summary>
        /// Ensures that the stored lumps contain the correct index.  This should be called any time the list is modified.
        /// </summary>
        void ValidateLumpIndices()
        {
            for (int i = 0; i < m_entries.Count; ++i)
            {
                m_entries[i].Index = i;
            }
        }
    }
}