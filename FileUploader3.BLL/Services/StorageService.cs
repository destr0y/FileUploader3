using FileUploader3.BLL.Interfaces;
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
                File.Move($"Storage/{sourceName}", destName);
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
            try
            {
                File.Delete($"Storage/{fileName}");
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
                File.Copy(filePath, $"Storage/{Path.GetFileName(filePath)}");

                var file = new FileInfo($"Storage/{Path.GetFileName(filePath)}");

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
            catch
            {
                return "Something went wrong";
            }
        }
    }
}
