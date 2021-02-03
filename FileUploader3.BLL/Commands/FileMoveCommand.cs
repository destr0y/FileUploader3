using FileUploader3.BLL.Services;
using FileUploader3.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using FileUploader3.DAL.Services;

namespace FileUploader3.BLL.Commands
{
    public class FileMoveCommand : ICommand
    {
        public static readonly string Pattern = "file move \"(.+)\" \"(.+)\"";

        public FileMoveCommand(string cmd)
        {
            var args = Regex.Match(cmd, Pattern).Groups;

            sourceName = args[1].Value;
            destName = args[2].Value;
        }

        private string sourceName;
        private string destName;

        public string Execute()
        {
            if (!UserService.GetInstance().User.IsAuthorized)
            {
                return "You must log in firstly!";
            }
            return StorageService.GetInstance().Move(sourceName, destName);
        }
    }
}
