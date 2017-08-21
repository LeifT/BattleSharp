using Newtonsoft.Json;

namespace BattleSharp.Wow.AuctionAPI {
    public class AuctionFile {
        [JsonProperty]
        public string Url { get; private set; }

        [JsonProperty]
        public long LastModified { get; private set; }
    }
}