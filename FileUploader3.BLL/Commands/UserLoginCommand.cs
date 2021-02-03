using FileUploader3.BLL.Services;
using FileUploader3.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using FileUploader3.DAL.Services;

namespace FileUploader3.BLL.Commands
{
    public class UserLoginCommand : ICommand
    {
        public static readonly string Pattern = "--login \"(.+)\" --password \"(.+)\"";

        public UserLoginCommand(string cmd)
        {
            var args = Regex.Match(cmd, Pattern).Groups;

            name = args[1].Value;
            password = args[2].Value;
        }

        private string name;
        private string password;

        public string Execute()
        {
            return UserService.GetInstance().SignIn(name, password);
        }
    }
}
