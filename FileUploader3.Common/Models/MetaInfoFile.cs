using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileUploader3.Common.Models
{
    [Serializable]
    public class MetaInfoFile
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public DateTime CreationDate { get; set; }
        public int DownloadsCount { get; set; }

        public MetaInfoFile(FileInfo file)
        {
            Name = file.Name;
            Extension = file.Extension;
            Size = file.Length;
            CreationDate = file.CreationTime;
        }
    }
}
