using Newtonsoft.Json;

namespace App.Services
{
    public static class JsonService
    {
        public static T? ParseJsonFileToModel<T>(string jsonFileLocation)
        {
            using var file = File.OpenText(jsonFileLocation);
            using var reader = new JsonTextReader(file);

            var serializer = new JsonSerializer();

            return serializer.Deserialize<T>(reader);
        }
    }
}
