using FileUploader3.BLL.Interfaces;

namespace FileUploader3.BLL.Commands
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
