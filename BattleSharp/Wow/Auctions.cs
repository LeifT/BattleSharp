using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleSharp.Wow {
    [JsonObject]
    public class Auctions : IEnumerable<Auction> {
        [JsonProperty]
        public ICollection<Auction> auctions { get; set; }

        public IEnumerator<Auction> GetEnumerator() {
            return auctions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}