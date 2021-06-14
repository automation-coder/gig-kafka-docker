using Newtonsoft.Json;

namespace kafka_console_app.util
{
    public class JsonActions
    {
        public static T CreateObjectFromJson<T>(string filePath)
        {
            string jsonContent = FileActions.GetContents(filePath);
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
}
