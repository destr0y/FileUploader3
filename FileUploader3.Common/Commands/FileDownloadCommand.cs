using FileUploader3.Bll.Services;
using FileUploader3.Common.Interfaces;
using System.Text.RegularExpressions;

namespace FileUploader3.Common.Commands
{
    public class FileDownloadCommand : ICommand
    {
        private string sourceFile;
        private string destFile;

        public static readonly string Pattern = "file download \"(.+)\" \"(.+)\"";

        public FileDownloadCommand(string cmd)
        {
            var args = Regex.Match(cmd, Pattern).Groups;

            sourceFile = args[1].Value;
            destFile = args[2].Value;
        }

        public string Execute()
        {
            return StorageService.GetInstance().Download(sourceFile, destFile);
        }
    }
}
