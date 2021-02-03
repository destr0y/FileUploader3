using FileUploader3.BLL.Interfaces;
using FileUploader3.DAL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FileUploader3.BLL.Commands
{
    public class FileInfoCommand : ICommand
    {
        public static readonly string Pattern = "file info \"(.+)\"";

        private string fileName;

        public FileInfoCommand(string cmd)
        {
            var args = Regex.Match(cmd, Pattern).Groups;

            fileName = args[1].Value;
        }

        public string Execute()
        {
            if (!UserService.GetInstance().IsAuthorized)
            {
                return "You must log in firstly!";
            }

            var file = MetaInfoService.GetInstance().Info(fileName);
            
            if (file == null)
            {
                return "File was not found!";
            }

            return $"Name: {file.Name}\n" +
                   $"Extension: {file.Extension}\n" +
                   $"Size: {file.Size}\n" +
                   $"CreationDate: {file.CreationDate}\n" +
                   $"Login: {UserService.GetInstance().User.Name}";
        }
    }
}
