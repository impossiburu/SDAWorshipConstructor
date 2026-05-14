using SDAWorshipDraft.Interfaces;
using System.Text.Json;

namespace SDAWorshipDraft.Services
{
    public class JsonFileService : IJsonFileInterface
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public T Load<T>(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Path not found");
            }
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            string json = File.ReadAllText(path);

            return JsonSerializer.Deserialize<T>(json)
                ?? throw new JsonException("Invalid JSON");
        }

        public void Save<T>(string path, T data)
        {
            string json = JsonSerializer.Serialize(data, _jsonOptions);
            File.WriteAllText(path, json);
        }
    }
}
