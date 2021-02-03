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
        public string Execute()
        {
            var userService = UserService.GetInstance();
            if (!userService.IsAuthorized)
        }
    }
}
