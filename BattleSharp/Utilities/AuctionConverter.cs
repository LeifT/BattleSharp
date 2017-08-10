using System;
using System.Collections.Generic;
using BattleSharp.Wow;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BattleSharp.Utilities {
    public class AuctionConverter : JsonConverter {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            JObject item = JObject.Load(reader);

            Auctions root = new Auctions();
            root.auctions = item["auctions"].ToObject<ICollection<Auction>>(serializer);

            return root;
        }

        public override bool CanConvert(Type objectType) {
            return objectType == typeof(Auctions);
        }
    }
}