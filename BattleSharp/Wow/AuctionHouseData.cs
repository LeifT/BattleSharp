using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleSharp.Wow {
    public class AuctionHouseData  {
        [JsonProperty]
        public ICollection<Auction> Auctions { get; private set; }

        [JsonProperty]
        public ICollection<Realm> Realms { get; private set; }
    }
}