using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleSharp.Wow.RealmStatus {
    public class Realm {
        public string Type { get; set; }
        public string Population { get; set; }
        public bool Queue { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Battlegroup { get; set; }
        public string Locale { get; set; }
        public string Timezone { get; set; }

        [JsonProperty(PropertyName = "connected_realms")]
        public IList<string> ConnectedRealms { get; set; }
    }
}