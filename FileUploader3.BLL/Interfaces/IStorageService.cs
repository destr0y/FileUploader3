﻿namespace FileUploader3.BLL.Interfaces
{
    public interface IStorageService
    {
        string Download(string sourceFile, string destFile);
        string Move(string sourceName, string destName);
        string Remove(string fileName);
        string Upload(string filePath);
    }
}
