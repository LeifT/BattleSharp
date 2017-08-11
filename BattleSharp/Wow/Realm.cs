using Newtonsoft.Json;

namespace BattleSharp.Wow {
    public class Realm {
        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public string Slug { get; private set; }
    }
}