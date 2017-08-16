using System.Collections.Generic;
using BattleSharp.Wow.RealmStatus;
using Newtonsoft.Json;

namespace BattleSharp.Wow.Auction {
    public class AuctionDataDump  {
        [JsonProperty]
        public ICollection<Auction> Auctions { get; private set; }

        [JsonProperty]
        public ICollection<Realm> Realms { get; private set; }
    }
}