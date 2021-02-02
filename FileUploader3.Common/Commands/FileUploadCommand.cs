using FileUploader3.Bll.Services;
using FileUploader3.Common.Interfaces;
using System.Text.RegularExpressions;

namespace FileUploader3.Common.Commands
{
    public class FileUploadCommand : ICommand
    {
        public static readonly string Pattern = "file upload \"(.+)\"";
        private string filePath;

        public FileUploadCommand(string cmd)
        {
            filePath = Regex.Match(cmd, Pattern).Groups[1].Value;
        }

        public string Execute()
        {
            return StorageService.GetInstance().Upload(filePath);
        }

    }
}
