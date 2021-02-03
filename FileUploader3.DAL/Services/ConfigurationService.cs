using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileUploader3.DAL.Services
{
    public class ConfigurationService
    {
        private static ConfigurationService instance;

        public static ConfigurationService GetInstance()
        {
            if (instance == null)
            {
                instance = new ConfigurationService();
            }

            return instance;
        }

        private ConfigurationService()
        {
            Configure();
        }

        private IConfigurationRoot configuration;

        public string UserName => configuration["User:Name"];
        public string UserPassword => configuration["User:Password"];
        //public DateTime UserCreationDate => new DateTime(configuration["User:CreationDate"]);

        public long StorageMaxCapacity => long.Parse(configuration["Storage:Capacity"]);
        public long StorageMaxFileSize => long.Parse(configuration["Storage:MaxFileSize"]);

        private void Configure()
        {
            configuration = new ConfigurationBuilder().AddJsonFile(@"appsettings.json").Build();
        }
    }
}
