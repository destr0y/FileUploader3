using FileUploader3.Common.Models;
using FileUploader3.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileUploader3.DAL.Services
{
    public class UserService : IUserService
    {
        private static UserService userService;

        public static UserService GetInstance()
        {
            if (userService == null)
            {
                userService = new UserService();
            }

            return userService;
        }

        private UserService()
        {
            var configuration = ConfigurationService.GetInstance();
            User = new User(configuration.UserName, configuration.UserPassword, DateTime.Now);
        }

        public bool IsAuthorized { get; private set; }
        public User User { get; private set; }

        public string SignIn(string name, string password)
        {
            if (IsAuthorized)
            {
                return "You are already authorized!"; 
            }
            if (name == User.Name && password == User.Password)
            {
                IsAuthorized = true;
                return "You have successfully logged in";
            }

            return "Invalid username or password!";
        }
    }
}
