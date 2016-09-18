using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace CR_DeckAnalysis
{
    public static class IO
    {
        public static void StringList_Export(List<Tuple<string, string, string, string>> exportObject, string FileName, string FileType = ".txt")
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

        public static void StringList_Export(List<Tuple<string, string,string>> exportObject, string FileName, string FileType = ".txt")
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


        public static void StringList_Export(List<string> exportObject, string FileName, string FileType = ".txt")
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

        public static List<string> StringList_Import(string filePath)
        {
            List<string> tmpData;
            string rawJSONstring = File.ReadAllText(filePath);
            tmpData = JsonConvert.DeserializeObject<List<string>>(rawJSONstring);
            return tmpData;
        }

        public static List<Tuple<string, string, string>> StringList_Import_3(string filePath, string FileType = ".txt")
        {
            List<Tuple<string, string, string>> tmpData;
            string rawJSONstring = File.ReadAllText(filePath + FileType);
            tmpData = JsonConvert.DeserializeObject<List<Tuple<string, string, string>>>(rawJSONstring);
            return tmpData;
        }

        public static List<Tuple<string, string, string, string>> StringList_Import_4(string filePath, string FileType = ".txt")
        {
            List<Tuple<string, string, string, string>> tmpData;
            string rawJSONstring = File.ReadAllText(filePath + FileType);
            tmpData = JsonConvert.DeserializeObject<List<Tuple<string, string, string, string>>>(rawJSONstring);
            return tmpData;
        }



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



        public static ObservableCollection<CardGroupReport> CardGroupReports_Import(string filePath, string FileType = ".txt")
        {
          //  List<CardGroupReport> tmpPreData;
            ObservableCollection<CardGroupReport> tmpData;
            string rawJSONstring = File.ReadAllText(filePath + FileType);
          //  tmpPreData = JsonConvert.DeserializeObject<List<CardGroupReport>>(rawJSONstring);
            //tmpData = new ObservableCollection<CardGroupReport>(tmpPreData);
            tmpData = JsonConvert.DeserializeObject<ObservableCollection<CardGroupReport>>(rawJSONstring);
            return tmpData;
        }



        public static void CardGroupReports_Export(ObservableCollection<CardGroupReport> exportObject, string FileName, string FileType = ".txt")
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

        public static void CardGroupReportsList_Export(List<CardGroupReport> exportObject, string FileName, string FileType = ".txt")
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

    }
}
