using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BattleSharp.Wow.Mount {
    public class MountConvernter : JsonConverter {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            if (reader.TokenType == JsonToken.Null) {
                return string.Empty;
            }
            Console.WriteLine("HAAHA");
            JObject item = JObject.Load(reader);
            
            return item["mounts"].ToObject<ICollection<Mount>>();
        }

        public override bool CanConvert(Type objectType) {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}