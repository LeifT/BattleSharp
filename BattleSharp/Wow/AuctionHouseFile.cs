using Newtonsoft.Json;

namespace BattleSharp.Wow {
    public class AuctionHouseFile {
        [JsonProperty]
        public string Url { get; private set; }

        [JsonProperty]
        public long LastModified { get; private set; }
    }
}