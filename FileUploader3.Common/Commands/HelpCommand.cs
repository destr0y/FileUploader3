using FileUploader3.Common.Interfaces;

namespace FileUploader3.Common.Commands
{
    public class HelpCommand : ICommand
    {
        public string Execute()
        {
            return $"Commands: \n" +
                   $"\tfile upload \"<FilePath>\"\n" +
                   $"\tfile download \"<SourceFile>\" \"<DestFile>\"\n" +
                   $"\tfile remove \"<FileName>\"";
        }
    }
}
