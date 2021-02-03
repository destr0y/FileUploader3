using FileUploader3.BLL.Interfaces;
using FileUploader3.DAL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileUploader3.BLL.Commands
{
    public class UserInfoCommand : ICommand
    {
        public static readonly string Pattern = "user info";

        public UserInfoCommand(string cmd)
        {

        }

        public string Execute()
        {
            var userService = UserService.GetInstance();
            if (!userService.IsAuthorized)
            {
                return "You must log in firstly!";
            }

            return $"Login: {userService.User.Name}\n" +
                   $"Creation date: {userService.User.CreationDate.ToString("yyyy:MM:dd")}\n" +
                   $"Storage used: Bytes";
        }
    }
}
