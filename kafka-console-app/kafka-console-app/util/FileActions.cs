using System.IO;

namespace kafka_console_app.util
{
    public class FileActions
    {
        public static string GetContents(string filepath)
        {
            return File.ReadAllText("../../.." + filepath);
        }
    }
}
