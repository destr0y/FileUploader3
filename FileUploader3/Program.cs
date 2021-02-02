using FileUploader3.Common.Commands;
using FileUploader3.Common.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace FileUploader3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("> ");

                ICommand command = Console.ReadLine() switch
                {
                    var cmd when Regex.IsMatch(cmd, FileUploadCommand.Pattern) => new FileUploadCommand(cmd),
                    var cmd when Regex.IsMatch(cmd, FileDownloadCommand.Pattern) => new FileDownloadCommand(cmd),
                    var cmd when Regex.IsMatch(cmd, FileRemoveCommand.Pattern) => new FileRemoveCommand(cmd),
                    _ => new HelpCommand()
                };

                try
                {
                    var result = command.Execute();
                    Console.WriteLine(result);
                }
                catch
                {
                    Console.WriteLine("Something went wrong");
                }
            }
        }
    }
}
