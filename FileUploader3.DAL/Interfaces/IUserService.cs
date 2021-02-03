using FileUploader3.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileUploader3.DAL.Interfaces
{
    interface IUserService
    {
        string SignIn(string name, string password);
    }
}
