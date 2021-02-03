using FileUploader3.BLL.Interfaces;
using FileUploader3.DAL.Services;
using System;
using System.IO;

namespace FileUploader3.BLL.Services
{
    public class StorageService : IStorageService
    {
        private static StorageService instance;

        public static StorageService GetInstance()
        {
            Directory.CreateDirectory("Storage");
            instance ??= new StorageService();

            return instance;
        }

        private StorageService()
        {
            var configuration = ConfigurationService.GetInstance();

            Capacity = 
            MaxCapacity = configuration.StorageMaxCapacity;
            MaxFileSize = configuration.StorageMaxFileSize;
        }

        private long Capacity { get; set; }
        private long MaxCapacity { get; set; }
        private long MaxFileSize { get; set; }

        public string Download(string sourceFile, string destFile)
        {
            try
            {
                File.Copy($"Storage/{sourceFile}", destFile);
                return $"The file \"{sourceFile}\" has been downloaded";
            }
            catch (ArgumentException)
            {
                return "Invalid file name!";
            }
            catch (FileNotFoundException)
            {
                return "File was not found!";
            }
            catch (PathTooLongException)
            {
                return "Path is too long!";
            }
            catch (DirectoryNotFoundException)
            {
                return "Invalid path or file name!";
            }
            catch (IOException)
            {
                return $"The file {destFile} currently exists!";
            }
            catch (UnauthorizedAccessException)
            {
                return "You don't have permission to do this!";
            }
            catch
            {
                return "Something went wrong";
            }
        }

        public string Move(string sourceName, string destName)
        {
            if (Path.GetDirectoryName(destName) != string.Empty)
            {
                return "Source name must not be a directory!";
            }

            try
            {
                File.Move($"Storage/{sourceName}", $"Storage/{destName}");
                MetaInfoService.GetInstance().Update(sourceName, destName);

                return $"The file {sourceName} has been moved to {destName}";
            }
            catch (FileNotFoundException)
            {
                return "File was not found!";
            }
            catch (ArgumentException)
            {
                return "Invalid file name!";
            }
            catch (UnauthorizedAccessException)
            {
                return "You do not have permission to do this!";
            }
            catch (PathTooLongException)
            {
                return "Path is too long!";
            }
            catch (NotSupportedException)
            {
                return "Invalid file name!";
            }
            catch (IOException)
            {
                return $"The file {destName} already exists";
            }
            catch
            {
                return "Something went wrong";
            }
        }

        public string Remove(string fileName)
        {
            if (!File.Exists($"Storage/{fileName}"))
            {
                return "File was not found!";
            }

            try
            {
                File.Delete($"Storage/{fileName}");
                MetaInfoService.GetInstance().Delete(fileName);

                return $"The file {fileName} has been removed";
            }
            catch (ArgumentException)
            {
                return "Invalid file name!";
            }
            catch (NotSupportedException)
            {
                return "Invalid file name!";
            }
            catch (IOException)
            {
                return "The file is in use!";
            }
            catch (UnauthorizedAccessException)
            {
                return "You do not have permisiion to do this!";
            }
            catch
            {
                return "Something went wrong";
            }
        }

        public string Upload(string filePath)
        {
            try
            {
                var fileName = Path.GetFileName(filePath);

                File.Copy(filePath, $"Storage/{fileName}");
                MetaInfoService.GetInstance().Add(fileName);

                var file = new FileInfo($"Storage/{fileName}");

                return $"The file \"{filePath}\" has been uploaded \n" +
                       $" - File name: {file.Name} \n" +
                       $" - File size: {file.Length} Bytes \n" +
                       $" - File extension: {file.Extension}";
            }
            catch (ArgumentException)
            {
                return "Invalid file name!";
            }
            catch (FileNotFoundException)
            {
                return "File was not found!";
            }
            catch (PathTooLongException)
            {
                return "Path is too long!";
            }
            catch (DirectoryNotFoundException)
            {
                return "Directory was not found!";
            }
            catch (IOException)
            {
                return $"The file {Path.GetFileName(filePath)} currently exists!";
            }
            catch (UnauthorizedAccessException)
            {
                return "You don't have permission to do this!";
            }
            catch (Exception ex)
            {
                return "Something went wrong";
            }
        }
    }
}
