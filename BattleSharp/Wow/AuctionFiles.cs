using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleSharp.Wow {
    [JsonObject]
    public class AuctionFiles : IEnumerable<AuctionFile> {
        [JsonProperty]
        private IEnumerable<AuctionFile> files {
            get; set; 
        }

        public IEnumerator<AuctionFile> GetEnumerator() {
            return files.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}