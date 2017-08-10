using System;
using System.Collections;
using System.Collections.Generic;
using BattleSharp.Wow;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BattleSharp.Utilities {
    public class AuctionFileConverter : JsonConverter {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            JObject item = JObject.Load(reader);

            AuctionFiles root = new AuctionFiles();
            root.Files = item["files"].ToObject<ICollection<AuctionFile>>(serializer);
            
            return root;
        }

        public override bool CanConvert(Type objectType) {
            return objectType == typeof(AuctionFiles);
        }
    }
}