using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BattleSharp.Wow.Mount;
using Newtonsoft.Json;

namespace BattleSharp.Utilities {

    public static class JsonUtilities {
        private static readonly HttpClient httpClient;

        //static async Task<T> GetProductAsync<T>(string path) where T : class
        //{
        //    T product = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode) {
        //        product = await response.Content.ReadAsAsync<String>();
        //    }
        //    return product;
        //}

        static JsonUtilities() {
            var handler = new HttpClientHandler {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            httpClient = new HttpClient(handler);
        }

        private static T DeserializeStream<T>(Stream jsonStream) where T : class {
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

                    serializer.Converters.Add(new MountConvernter());

                    deserializedObject = serializer.Deserialize<T>(jsonReader);
                }
            }

            return deserializedObject;
        }

        public static async Task<T> DeserializeUrlAync<T>(string url) where T : class {
            if (url == null) {
                throw new ArgumentNullException(nameof(url));
            }

            if (string.IsNullOrWhiteSpace(url)) {
                throw new ArgumentException(nameof(url));
            }

            Stream jsonStream;

            using (var client = new HttpClient()) {
                jsonStream = await client.GetStreamAsync(url).ConfigureAwait(false);
            }
            
            return DeserializeStream<T>(jsonStream);
        }
    }
}