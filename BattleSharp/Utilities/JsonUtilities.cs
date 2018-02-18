using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BattleSharp.Utilities {

    public static class JsonUtilities {

        //static HttpClient client = new HttpClient();

        //static async Task<T> GetProductAsync<T>(string path) where T : class
        //{
        //    T product = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode) {
        //        product = await response.Content.ReadAsAsync<String>();
        //    }
        //    return product;
        //}


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
            
            var handler = new HttpClientHandler {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            Stream jsonStream;

            using (var client = new HttpClient(handler)) {
                jsonStream = await client.GetStreamAsync(url);
            }
            
            return DeserializeStream<T>(jsonStream);
        }
    }
}