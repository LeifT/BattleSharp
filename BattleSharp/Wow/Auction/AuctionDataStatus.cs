using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleSharp.Wow.Auction {
    [JsonObject]
    public class AuctionDataStatus : IEnumerable<AuctionFile> {
        [JsonProperty]
        public IList<AuctionFile> Files { get; private set; }

        public IEnumerator<AuctionFile> GetEnumerator() {
            return Files.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}