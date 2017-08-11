using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BattleSharp.Utilities {

    public static class JsonUtilities {
        public static T DeserializeStream<T>(Stream jsonStream) where T : class {
            if (jsonStream == null) {
                throw new ArgumentNullException(nameof(jsonStream));
            }

            if (jsonStream.CanRead == false) {
                throw new ArgumentException("Stream must support reading", nameof(jsonStream));
            }

            T deserializedObject;

            using (StreamReader streamReader = new StreamReader(jsonStream)) {
                using (JsonTextReader jsonReader = new JsonTextReader(streamReader)) {
                    JsonSerializer serializer = new JsonSerializer();
                    
                    deserializedObject = serializer.Deserialize<T>(jsonReader);
                }
            }

            return deserializedObject;
        }

        public static T DeserializeUrl<T>(string url) where T : class {
            var client = new HttpClient();
            var jsonStream = client.GetStreamAsync(url);
            return DeserializeStream<T>(jsonStream.ConfigureAwait(false).GetAwaiter().GetResult());
        }

        public static async Task<T> DeserializeUrlAync<T>(string url) where T : class {
            var client = new HttpClient();
            var jsonStream = await client.GetStreamAsync(url);
            return DeserializeStream<T>(jsonStream);
        }
    }
}