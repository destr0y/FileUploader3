using FileUploader3.Bll.Services;
using FileUploader3.Common.Interfaces;
using System.Text.RegularExpressions;

namespace FileUploader3.Common.Commands
{
    public class FileRemoveCommand : ICommand
    {
        public static readonly string Pattern = "file remove \"(.+)\"";

        string fileName;

        public FileRemoveCommand(string cmd)
        {
            fileName = Regex.Match(cmd, Pattern).Groups[1].Value;
        }

        public string Execute()
        {
            return StorageService.GetInstance().Remove(fileName);
        }
    }
}
