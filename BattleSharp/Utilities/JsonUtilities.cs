using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BattleSharp.Utilities {

    public static class JsonUtilities {
        public static T DeserializeStream<T>(Stream jsonStream) where T : class {
            if (jsonStream == null) {
                throw new ArgumentNullException(nameof(jsonStream));
            }

            if (jsonStream.CanRead == false) {
                throw new ArgumentException("Stream must support reading", nameof(jsonStream));
            }

            JsonSerializer serializer = new JsonSerializer();

            T deserializedObject;

            using (StreamReader streamReader = new StreamReader(jsonStream)) {
                using (JsonTextReader jsonReader = new JsonTextReader(streamReader)) {
                    deserializedObject = serializer.Deserialize<T>(jsonReader);
                }
            }

               

            return deserializedObject;
        }

        //public static void DeserializeStream<T>(Stream jsonStream, T ob) where T : class {
        //    if (jsonStream == null) {
        //        throw new ArgumentNullException(nameof(jsonStream));
        //    }

        //    if (jsonStream.CanRead == false) {
        //        throw new ArgumentException("Stream must support reading", nameof(jsonStream));
        //    }

        //    JsonSerializer serializer = new JsonSerializer();

        //    using (StreamReader streamReader = new StreamReader(jsonStream)) {
        //        using (JsonTextReader jsonReader = new JsonTextReader(streamReader)) {
        //            serializer.Populate(jsonReader, ob);
        //        }
        //    }
        //}

        public static async Task<T> DeserializeStreamFromUrl<T>(string url) where T : class {
            var client = new HttpClient();
            var task = client.GetStreamAsync(url);
            
            //return DeserializeStream<T>(task.GetAwaiter().GetResult());
            //var jsonStream = DeserializeStream<T>(task.GetAwaiter().GetResult());

            // Task<T> deserializedObject;

            Task<JObject> deserializedObject;

            T potato;

            using (StreamReader streamReader = new StreamReader(await task))
            {
                using (JsonTextReader jsonReader = new JsonTextReader(streamReader)) {
                    JsonSerializer asdf = new JsonSerializer();
                    potato = asdf.Deserialize<T>(jsonReader);
                     deserializedObject = JObject.LoadAsync(jsonReader);
                    //deserializedObject = serializer.Deserialize<T>(jsonReader);
                }
            }

            return potato;

            var asd = deserializedObject.Result.ToObject<T>();
            
            return asd;
        }
    }
}