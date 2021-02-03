using FileUploader3.BLL.Services;
using FileUploader3.BLL.Interfaces;
using System.Text.RegularExpressions;
using FileUploader3.DAL.Services;

namespace FileUploader3.BLL.Commands
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
            if (!UserService.GetInstance().IsAuthorized)
            {
                return "You must log in firstly";
            }
            return StorageService.GetInstance().Download(sourceFile, destFile);
        }
    }
}
