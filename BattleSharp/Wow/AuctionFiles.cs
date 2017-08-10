using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleSharp.Wow {
    [JsonObject]
    public class AuctionFiles : IEnumerable<AuctionFile> {
        [JsonProperty]
        public ICollection<AuctionFile> Files {
            get; set; 
        }

        public IEnumerator<AuctionFile> GetEnumerator() {
            return Files.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}