using FileUploader3.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FileUploader3.DAL.Services
{
    public class MetaInfoService
    {
        private static MetaInfoService instance;

        public static MetaInfoService GetInstance()
        {
            if (instance == null)
            {
                instance = new MetaInfoService();
            }

            return instance;
        }

        private MetaInfoService()
        {
            Files = new Dictionary<string, MetaInfoFile>();

            if (File.Exists("Storage/storage.dat"))
            {
                using (FileStream fs = File.Open("Storage/storage.dat", FileMode.OpenOrCreate))
                {
                    var formatter = new BinaryFormatter();
                    Files = (Dictionary<string, MetaInfoFile>)formatter.Deserialize(fs);
                }
            }
        }

        private Dictionary<string, MetaInfoFile> Files { get; set; }

        public void Add(string fileName)
        {
            var file = new FileInfo($"Storage/{fileName}");
            Files.Add(file.Name, new MetaInfoFile(file));

            Save();
        }

        public void Update(string sourceFile, string destFile)
        {
            var file = new FileInfo($"Storage/{destFile}");
            Files.Add(file.Name, Files[sourceFile]);
            Files.Remove(sourceFile);

            Save();
        }

        public void Delete(string fileName)
        {
            Files.Remove(fileName);

            Save();
        }

        public void Download(string fileName)
        {
            ++Files[fileName].DownloadsCount;

            Save();
        }

        public MetaInfoFile Info(string fileName)
        {
            if (Files.ContainsKey(fileName))
            {
                return Files[fileName];
            }
            return null;
        }

        public void Save()
        {
            using (FileStream fs = File.Open("Storage/storage.dat", FileMode.OpenOrCreate))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fs, Files);
            }
        }
    }
}
