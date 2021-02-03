using FileUploader3.BLL.Commands;
using FileUploader3.BLL.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace FileUploader3.CLI
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
                    var cmd when Regex.IsMatch(cmd, FileMoveCommand.Pattern) => new FileMoveCommand(cmd),
                    var cmd when Regex.IsMatch(cmd, UserLoginCommand.Pattern) => new UserLoginCommand(cmd),
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
