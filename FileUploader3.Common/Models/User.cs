using System;
using System.Collections.Generic;
using System.Text;

namespace FileUploader3.Common.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }

        public User(string name, string password, DateTime creationDate)
        {
            Name = name;
            Password = password;
            CreationDate = creationDate;
        }
    }
}
