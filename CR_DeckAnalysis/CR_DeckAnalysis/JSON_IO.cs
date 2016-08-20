using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CR_DeckAnalysis
{
    public static class IO
    {
        public static void DeckList_Export(List<Deck> exportObject, string FileName, string FileType = ".txt")
        {
            string jsonData = JsonConvert.SerializeObject(exportObject);
            string fileName = FileName + FileType;
            FileStream fcreate = File.Open(fileName, FileMode.Create);
            using (StreamWriter writer = new StreamWriter(fcreate))
            {
                writer.Write(jsonData);
                writer.Close();
            }
        }

        public static List<Deck> DeckList_Import(string filePath)
        {
            List<Deck> tmpData;
            string rawJSONstring = File.ReadAllText(filePath);
            tmpData = JsonConvert.DeserializeObject<List<Deck>>(rawJSONstring);
            return tmpData;
        }
    }
}
