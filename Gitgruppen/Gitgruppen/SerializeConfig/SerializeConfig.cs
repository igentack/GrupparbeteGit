using System.Text.Json;

namespace Gitgruppen.SerializeConfig
{
    public class SerializeConfig
    {
        public class ConfigObject
        {

        }
        public ConfigObject ReadFromFile() {
            string fileName = "SerializeObject\\appconfig.json";
            string jsonString = File.ReadAllText(fileName);
            ConfigObject conf = JsonSerializer.Deserialize<ConfigObject>(jsonString)!;

            return conf;
        }

        public async Task WriteToFileAsync(ConfigObject configObject)
        {
            string fileName = "SerializeObject\\appconfig.json";
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, configObject);
            await createStream.DisposeAsync();
        }
    }
}
