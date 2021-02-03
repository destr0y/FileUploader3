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
        public bool IsAuthorized { get; set; }
    }
}
